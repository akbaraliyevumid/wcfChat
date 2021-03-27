using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))] //Etot atribut govorit ot om chto interfeys nije budet predstavlyat soboy dogovorennost o tom chto kak nash kliyent budet vzaimodeystvovat s nashim serverom.
    public interface IServiceChat
    {
        [OperationContract] // v kajdom metode interfeysa dolgen bit etot atribut, to yest metod v kotorom yest etot kontrakt budet viden so storoni kliyenta.
        int Connect(string name); // S pomoshyu etojo metoda budem podklyuchatsya k servisu.

        [OperationContract]
        void Disconnect(int id); // Etot metod budet vizivatsya kogda kliyent pokidayet chat. Nujet on nam dlya togo chto bi soobshit nashemu servisu o tom chto takogo kliyenta u nego bolshe netu.

        [OperationContract(IsOneWay = true)]//Yesli ne nujno dojidatsya otveta ot servera dobavim parametr IsOneWat so znacheniyem true.
        void SendMessage(string message, int id);//Etot metod prinimayet strokovoye soobsheniye.
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);
    }
}
