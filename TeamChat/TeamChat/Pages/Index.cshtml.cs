using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Xml.Linq;
using TeamChat.Models.DTO;
using TeamChat.Models.Interfaces.Data;
using TeamChat.ViewModels;

namespace TeamChat.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private IUserService _userService;
        //private IMessageInformationService _messageInformationService;
        private IMessageService _messageService;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IUserService userService, IMessageService messageService)
        {
            _logger = logger;
            _userService = userService;
            //_messageInformationService = messageInformationService;
            _messageService = messageService;
        }

        public int LoggedInUserId
        {
            get
            {
                int loggedInUserId;
                // base.User represents the Logged in Principal (.net authentication name for user)
                var userId = base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
                int.TryParse(userId, out loggedInUserId);

                return loggedInUserId;
            }
        }
        [BindProperty] public Messages Message { get; set; }
        public List<Messages> Messages { get; set; }
        public User User { get; set; }
        //public MessageInformation MessageInformation { get; set; }
        public List<User> Users { get; set; }
        public UserListViewModel UserListViewModel { get; set; }
        public SendFormViewModel SendFormViewModel { get; set; }
        public ConversationViewModel ConversationViewModel { get; set; }
        public void OnGet(string? name, int userId)
        {
            UserListViewModel = new UserListViewModel();
            if (name == null)
            {
                UserListViewModel.Users = _userService.GetAll();
                UserListViewModel.Messages = _messageService.GetById(LoggedInUserId);
            }
            else
            {
                UserListViewModel.Users = _userService.Search(name);
                UserListViewModel.Messages = _messageService.GetById(LoggedInUserId);
            }
            Message = new Messages()
            {
                SenderId = LoggedInUserId,
                ReceiverId = userId,
                MessageRead = false
            };

            SendFormViewModel = new SendFormViewModel();
            SendFormViewModel.Message = Message;
            ConversationViewModel = new ConversationViewModel();
            ConversationViewModel.Messages = _messageService.ConversationMessagesList(LoggedInUserId, userId);
            ConversationViewModel.Me = _userService.GetById(LoggedInUserId);
            ConversationViewModel.OtherUser = _userService.GetById(userId);

        }
        public IActionResult OnPost(string? name, int userId)
        {
            Message.DateSend = DateTime.Now;
            Message.TimeSend = DateTime.Now.TimeOfDay;
            _messageService.Add(Message);

            UserListViewModel = new UserListViewModel();
            if (name == null)
            {
                UserListViewModel.Users = _userService.GetAll();
                UserListViewModel.Messages = _messageService.GetById(LoggedInUserId);
            }
            else
            {
                UserListViewModel.Users = _userService.Search(name);
                UserListViewModel.Messages = _messageService.GetById(LoggedInUserId);
            }
            Message = new Messages()
            {
                SenderId = LoggedInUserId,
                ReceiverId = userId,
                MessageRead = false
            };

            SendFormViewModel = new SendFormViewModel();
            SendFormViewModel.Message = Message;
            return new RedirectToPageResult("/Index", new { userId=Message.ReceiverId });
        }

        //public void OnGet(int id)
        //{

        //}
    }
}