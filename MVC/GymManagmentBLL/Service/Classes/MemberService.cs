using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.MemberViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepostory<Member> _memberRepository;
        private readonly IGenericRepostory<Membership> _membershipRepostory;
        private readonly IGenericRepostory<Plan> _planRepostory;
        private readonly IGenericRepostory<HealthRecord> _healthRecordRepository;
        public MemberService(IGenericRepostory<Member> memberRepostory, 
            IGenericRepostory<Membership> membershipRepostory, 
            IGenericRepostory<Plan> planRepostory,
            IGenericRepostory<HealthRecord> healthRecordRepostory)
        {
            _memberRepository = memberRepostory;
            _membershipRepostory = membershipRepostory;
            _planRepostory = planRepostory;
            _healthRecordRepository = healthRecordRepostory;
        }

        public IEnumerable<MemberViewModels> GetAllMembers()
        {
            var Members = _memberRepository.GetAll();

            if (Members is null || !Members.Any())
                return [];

            var MemberViewModel = new List<MemberViewModels>();

            // Those 2 ways are Manaul Mapping, other method is using AutoMapper Library
            // Way using foreach
            foreach (var member in Members)
            {
                MemberViewModel.Add(new MemberViewModels // Mapping, took from Member what MemberViewModel need
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Phone = member.Phone,
                    Gender = member.Gender.ToString()
                });
            }

            /* Way using LINQ
            var MemberViewModelS = Members.Select(member => new MemberViewModels
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender.ToString()
            });
            */

            return MemberViewModel;
        }

        public bool CreateMember(CreateMemberViewModel createMemberViewModel)
        {
            try
            {
                var emailExists = _memberRepository.GetAll(m => m.Email == createMemberViewModel.Email).Any();
                var phoneExists = _memberRepository.GetAll(m => m.Phone == createMemberViewModel.Phone).Any();
                if (emailExists || phoneExists)
                    return false;

                var member = new Member
                {
                    Name = createMemberViewModel.Name,
                    Email = createMemberViewModel.Email,
                    Phone = createMemberViewModel.Phone,
                    Gender = createMemberViewModel.Gender,
                    DateOfBirth = createMemberViewModel.DateOfBirth,
                    Address = new Address
                    {
                        BuildingNumber = createMemberViewModel.BuildingNumber,
                        Street = createMemberViewModel.Street,
                        City = createMemberViewModel.City
                    },
                    HealthRecord = new HealthRecord
                    {
                        Height = createMemberViewModel.HealthRecord.Height,
                        Weight = createMemberViewModel.HealthRecord.Weight,
                        BloodType = createMemberViewModel.HealthRecord.BloodType,
                        Note = createMemberViewModel.HealthRecord.Note
                    }
                };

                return _memberRepository.Add(member) > 0;
            }
            catch
            {
                return false;
            }
        }

        public MemberViewModels? GetMemberDetails(int id)
        {
            var member = _memberRepository.GetById(id);
            if (member is null)
                return null;

            var memberViewModel = new MemberViewModels
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Photo = member.Photo,
                DateOfBirth = member.DateOfBirth.ToString("MM/dd/yyyy"),
                Gender = member.Gender.ToString(),
                Address = member.Address != null ? $"{member.Address.BuildingNumber}, {member.Address.Street}, {member.Address.City}" : null
            };

            var activeMembership = _membershipRepostory.GetAll(m => m.MemberId == member.Id && m.Status=="Active")
                .FirstOrDefault();

            if (activeMembership is not null)
            {
                memberViewModel.MembershipStartDate = activeMembership.CreatedAt.ToString("MM/dd/yyyy");
                memberViewModel.MembershipEndDate = activeMembership.EndDate.ToString("MM/dd/yyyy");
                var plan = _planRepostory.GetById(activeMembership.PlanId);
                memberViewModel.PlanName = plan?.Name;
            }

            return memberViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecordDetails(int MemberId)
        {
            var memberHealthRecord = _healthRecordRepository.GetById(MemberId);
            if (memberHealthRecord is null)
                return null;

            return new HealthRecordViewModel
            {
                Height = memberHealthRecord.Height,
                Weight = memberHealthRecord.Weight,
                BloodType = memberHealthRecord.BloodType,
                Note = memberHealthRecord.Note
            };
        }
    }
}
