using Ninject;
using SocialNetwork.Bll;
using SocialNetwork.BllContracts;
using SocialNetwork.DalContracts;
using SocialNetwork.MsSqlDal;

namespace SocialNetwork.DI
{
    public static class DependencyResolver
    {
        private static readonly IKernel kernel;

        public static IUserLogic UserLogic
        {
            get
            {
                return DependencyResolver.kernel.Get<IUserLogic>();
            }
        } 

        public static IAdminLogic AdminLogic
        {
            get
            {
                return DependencyResolver.kernel.Get<IAdminLogic>();
            }
        }

        public static IKernel Kernel
        {
            get
            {
                return DependencyResolver.kernel;
            }
        }

        static DependencyResolver()
        {
            DependencyResolver.kernel = new StandardKernel();
            InitializeDaos();
            InitializeLogics();
        }

        private static void InitializeDaos()
        {
            DependencyResolver.kernel.Bind<IUserDao>().To<UserDao>().InSingletonScope();
            DependencyResolver.kernel.Bind<IAdminDao>().To<AdminDao>().InSingletonScope();
            DependencyResolver.kernel.Bind<IMessageDao>().To<MessageDao>().InSingletonScope();
            DependencyResolver.kernel.Bind<IUserMessagesDao>().To<UserMessagesDao>().InSingletonScope();
            DependencyResolver.kernel.Bind<IFriendDao>().To<FriendDao>().InSingletonScope();
        }

        private static void InitializeLogics()
        {
            DependencyResolver.kernel.Bind<IAdminLogic>().To<AdminLogic>().InSingletonScope();
            DependencyResolver.kernel.Bind<IFriendLogic>().To<FriendLogic>().InSingletonScope();
            DependencyResolver.kernel.Bind<IMessageLogic>().To<MessageLogic>().InSingletonScope();
            DependencyResolver.kernel.Bind<IUserLogic>().To<UserLogic>().InSingletonScope();
            DependencyResolver.kernel.Bind<IUserMessageLogic>().To<UserMessageLogic>().InSingletonScope();
        }
    }
}