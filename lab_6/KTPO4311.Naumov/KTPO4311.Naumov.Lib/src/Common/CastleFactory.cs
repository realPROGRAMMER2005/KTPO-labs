using Castle.Windsor;

namespace KTPO4311.Naumov.Lib.src.Common
{
    
    public static class CastleFactory
    {
        /// <summary>Контейнер</summary>
        public static IWindsorContainer container { get; private set; }

        static CastleFactory()
        {
            // Создать объект контейнера
            container = new WindsorContainer();
        }
    }
}
