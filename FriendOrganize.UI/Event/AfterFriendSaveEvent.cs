using Prism.Events;

namespace FriendOrganize.UI.Event
{
  public class AfterFriendSaveEvent : PubSubEvent<AfterFriendSaveEventArg>
  {
  }

  public class AfterFriendSaveEventArg
  {
	  public int Id { get; set; }
	  public string DisplayMember { get; set; }
  }
}
