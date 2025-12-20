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
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MemberViewModels> GetAllMembers()
        {
            var Members = _unitOfWork.GetRepository<Member>().GetAll();

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
                if (IsEmailExist(createMemberViewModel.Email) || IsPhoneExist(createMemberViewModel.Phone))
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

                _unitOfWork.GetRepository<Member>().Add(member);
                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }

        public MemberViewModels? GetMemberDetails(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(id);
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

            var activeMembership = _unitOfWork.GetRepository<Membership>().GetAll(m => m.MemberId == member.Id && m.Status == "Active")
                .FirstOrDefault();

            if (activeMembership is not null)
            {
                memberViewModel.MembershipStartDate = activeMembership.CreatedAt.ToString("MM/dd/yyyy");
                memberViewModel.MembershipEndDate = activeMembership.EndDate.ToString("MM/dd/yyyy");
                var plan = _unitOfWork.GetRepository<Plan>().GetById(activeMembership.PlanId);
                memberViewModel.PlanName = plan?.Name;
            }

            return memberViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecordDetails(int MemberId)
        {
            var memberHealthRecord = _unitOfWork.GetRepository<HealthRecord>().GetById(MemberId);
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

        public MemberToUpdateViewModel? GetMemberToUpdate(int MemberId)
        {
            var Member = _unitOfWork.GetRepository<Member>().GetById(MemberId);
            if (Member is null)
                return null;

            return new MemberToUpdateViewModel()
            {
                Email = Member.Email,
                Name = Member.Name,
                Phone = Member.Phone,
                Photo = Member.Photo,
                BuildingNumber = Member.Address.BuildingNumber,
                Street = Member.Address.Street,
                City = Member.Address.City
            };
        }

        public bool UpdateMember(int MemberId, MemberToUpdateViewModel memberToUpdate)
        {
            try
            {
                if (IsEmailExist(memberToUpdate.Email) || IsPhoneExist(memberToUpdate.Phone))
                    return false;

                var memberRepo = _unitOfWork.GetRepository<Member>();
                var member = memberRepo.GetById(MemberId);
                if (member is null)
                    return false;

                member.Email = memberToUpdate.Email;
                member.Phone = memberToUpdate.Phone;
                member.Address.City = memberToUpdate.City;
                member.Address.Street = memberToUpdate.Street;
                member.Address.BuildingNumber = memberToUpdate.BuildingNumber;
                member.UpdatedAt = DateTime.Now;

                memberRepo.Update(member);
                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveMember(int MemberId)
        {
            var memberRepo = _unitOfWork.GetRepository<Member>();

            var member = memberRepo.GetById(MemberId);
            if (member is null)
                return false;

            // buisness rules
            var activeSession = _unitOfWork.GetRepository<MemberSession>().GetAll(x => x.MemberId == MemberId && x.Session.StartDate > DateTime.Now).Any();
            if (activeSession)
                return false;
            
            var membershipRepo = _unitOfWork.GetRepository<Membership>();
            var memberships = membershipRepo.GetAll(x => x.MemberId == MemberId);
            try 
            { 
                if (memberships.Any())
                    foreach (var m in memberships)
                        membershipRepo.Delete(m);

                memberRepo.Delete(member);
                return _unitOfWork.SaveChange() > 0;
            } 
            catch 
            {
                return false;
            }
        }

        #region Helper methods
        private bool IsEmailExist(string email)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(x => x.Email == email).Any();
        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(x => x.Phone == phone).Any();
        }
        #endregion
    }
}
