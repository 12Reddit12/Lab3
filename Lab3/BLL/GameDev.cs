using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    abstract class AbstractPublisher
    {
        private ArrayList subscriberList = new ArrayList();

        public void AddToClientList(AbstractComputer abstractSubscriber)
        {
            subscriberList.Add(abstractSubscriber);
        }

        public void DeleteFromClientList(AbstractComputer abstractSubscriber)
        {
            subscriberList.Remove(abstractSubscriber);
        }

        public void SendGameToClient()
        {
            int i = 0;

            foreach (AbstractComputer subscriber in subscriberList)
            {
                subscriber.Deliver();
            }
        }
    }


    class GameDev : AbstractPublisher
    {
        public GameDev()
        {
            Games = new List<IGame>();
            Games.Add(new Adventures("Adventures", 3, 4, 1, 50));
            Games.Add(new Strategy("Strategy", 2, 2, 2, 50));
            Games.Add(new RPG("RPG", 1, 1, 0.1, 0.5));

        }

        public List<IGame> Games { get; set; }
    }

}
