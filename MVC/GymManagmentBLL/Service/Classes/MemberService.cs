using AutoMapper;
using AutoMapper.Execution;
using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.Service.Interfaces.AttachmentService;
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
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork,
            IAttachmentService attachmentService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _attachmentService = attachmentService;
            _mapper = mapper;
        }

        public IEnumerable<MemberViewModels> GetAllMembers()
        {
            var Members = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll();
            if (Members is null || !Members.Any()) return [];
            #region Way01
            //var MemberViewmodel=new List<MemberViewModels>();
            //foreach (var Member in Members)
            //{
            //	var memberviewmodel = new MemberViewModels()
            //	{
            //		Id = Member.Id,
            //		Name = Member.Name,
            //		Email = Member.Email,
            //		Phone = Member.Phone,
            //		phote = Member.phote,
            //		Gender = Member.Gender.ToString()

            //	};
            //	MemberViewmodel.Add(memberviewmodel);
            //} 
            #endregion
            var MemberViewmodel = _mapper.Map<IEnumerable<MemberViewModels>>(Members);
            return MemberViewmodel;
        }

        public bool CreateMember(CreateMemberViewModel createMember)
        {
            try
            {
                if (IsEmailExist(createMember.Email) || IsPhoneExist(createMember.Phone))
                    return false;

                var photoName = _attachmentService.Upload("members", createMember.PhotoFile);
                if (string.IsNullOrEmpty(photoName)) return false;
                var member = _mapper.Map<GymManagmentDAL.Entities.Member>(createMember);
                member.Photo = photoName;

                _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().Add(member);
                var Iscreated = _unitOfWork.SaveChange() > 0;
                if (!Iscreated)
                {
                    _attachmentService.Delete(photoName, "members");
                    return false;

                }
                else
                    return Iscreated;


            }
            catch (Exception)
            {

                return false;
            }

        }

        public MemberViewModels? GetMemberDetails(int id)
        {
            var member = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetById(id);
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
            var Member = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetById(MemberId);
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
                var phoneexist = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(x => x.Phone == memberToUpdate.Phone && x.Id != MemberId);
                var emailexist = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(x => x.Email == memberToUpdate.Email && x.Id != MemberId);
                if (emailexist.Any() || phoneexist.Any())
                    return false;

                var memberRepo = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>();
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
            var memberRepo = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>();

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
                var IsDeleted = _unitOfWork.SaveChange() > 0;
                if (IsDeleted)
                {
                    _attachmentService.Delete(member.Photo, "members");
                }
                return IsDeleted;
            
            } 
            catch 
            {
                return false;
            }
        }

        #region Helper methods
        private bool IsEmailExist(string email)
        {
            return _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(x => x.Email == email).Any();
        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(x => x.Phone == phone).Any();
        }
        #endregion
    }
}
