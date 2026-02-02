using AutoMapper;
using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.SessionScheduleViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;

public class SessionScheduleService : ISessionScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SessionScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public bool BookSession(CreateSessionScheduleViewModel model)
    {
        try
        {
            var session = _unitOfWork.GetRepository<Session>().GetById(model.SessionId);
            if (session == null) return false;

            var currentBookings = _unitOfWork.GetRepository<MemberSession>()
                                 .GetAll(x => x.SessionId == model.SessionId).Count();

            if (currentBookings >= session.Capacity) return false; // Session is full

            var alreadyBooked = _unitOfWork.GetRepository<MemberSession>()
                                .GetAll(x => x.MemberId == model.MemberId && x.SessionId == model.SessionId).Any();
            if (alreadyBooked) return false;

            var booking = new MemberSession
            {
                MemberId = model.MemberId,
                SessionId = model.SessionId,
            };

            _unitOfWork.GetRepository<MemberSession>().Add(booking);
            return _unitOfWork.SaveChange() > 0;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<SessionScheduleViewModel> GetMemberSchedule(int memberId)
    {
        var bookings = _unitOfWork.GetRepository<MemberSession>()
                      .GetAll(x => x.Id == memberId);

        return bookings.Select(b => new SessionScheduleViewModel
        {
            Id = b.Id,
            MemberName = b.Member?.Name,
            SessionDescription = b.Session?.Description,
            TrainerName = b.Session?.SessionTrainer?.Name,
            StartTime = b.Session?.StartDate.ToString("g"),
            IsAttended = b.IsAttended
        }).ToList();
    }

    public IEnumerable<SessionScheduleViewModel> GetAllBookings()
    {
        var bookings = _unitOfWork.GetRepository<MemberSession>().GetAll();

        // Remember to use .Include() in your repo if possible, 
        // or fetch navigation properties as shown in the Membership logic.
        return bookings.Select(b => new SessionScheduleViewModel
        {
            Id = b.Id,
            MemberName = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetById(b.MemberId)?.Name,
            SessionDescription = _unitOfWork.GetRepository<Session>().GetById(b.SessionId)?.Description ?? "N/A",
            // _unitOfWork.GetRepository<GymManagmentDAL.Entities.Trainer>.GetById(_unitOfWork.GetRepository<Session>().GetById(b.SessionId)?.TrainerId))?.Name ?? "N/A"
            TrainerName = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Trainer>().GetById(_unitOfWork.GetRepository<Session>().GetById(b.SessionId).TrainerId)?.Name ?? "N/A",
            StartTime = _unitOfWork.GetRepository<Session>().GetById(b.SessionId)?.StartDate.ToString("f"),
            IsAttended = b.IsAttended
        }).ToList();
    }

    public bool CancelBooking(int bookingId)
    {
        var repo = _unitOfWork.GetRepository<MemberSession>();
        var booking = repo.GetById(bookingId);
        if (booking == null) return false;

        repo.Delete(booking);
        return _unitOfWork.SaveChange() > 0;
    }

    public bool ToggleAttendance(int bookingId)
    {
        var repo = _unitOfWork.GetRepository<MemberSession>();
        var booking = repo.GetById(bookingId);

        if (booking == null) return false;

        // Flip the status
        booking.IsAttended = !booking.IsAttended;

        repo.Update(booking);
        return _unitOfWork.SaveChange() > 0;
    }
}