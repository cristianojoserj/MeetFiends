using System;
using System.Linq;
using System.Collections.Generic;
using MeetFriends.Domain.Entities;

namespace MeetFriends.App
{
    public class Program
    {
        #region Global Fields

        public static List<Friend> friends = new List<Friend>();

        #endregion

        static void Main(string[] args)
        {
            var continued = true;

            #region Insert Friends

            Console.WriteLine("Entre com o nome dos seus amigos:");

            while (continued)
            {
                var friend = new Friend();

                Console.Write("Amigo: ");
                friend.Name = Console.ReadLine();

                Console.Write("Latitude: ");
                friend.FriendAddress.NumberLatitude = double.Parse(Console.ReadLine());

                Console.Write("Longitude: ");
                friend.FriendAddress.NumberLongitude = double.Parse(Console.ReadLine());

                friends.Add(friend);

                Console.Write("Continuar Cadastrando Amigo? (S/N)");
                continued = Console.ReadKey().Key.ToString().ToUpper() == "S";

                Console.WriteLine();
            }

            #endregion

            #region List Friends Added

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Amigos Adicionados:");
            Console.WriteLine("---------------------------------------------------");
            DisplayFriends(friends);

            #endregion

            #region Select Visit Friend

            Console.WriteLine("Informe o nome do amigo que voce está visitando:");
            continued = true;

            while (continued)
            {
                Console.Write("Amigo: ");
                var nomeAmigo = Console.ReadLine();

                if(friends.Any(p => p.Name == nomeAmigo))
                {
                    GetFriendsNext(nomeAmigo);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Amigos Mais Proximos:");
                    Console.WriteLine("---------------------------------------------------");
                    DisplayFriends(friends);
                }
                else
                {
                    Console.WriteLine("Amigo " + nomeAmigo + " não encontrado!");
                }

                Console.Write("Continuar pesquisando Amigo? (S/N)");
                continued = Console.ReadKey().Key.ToString().ToUpper() == "S";
                Console.WriteLine();
            }

            #endregion

            Console.WriteLine();
            Console.Write("Fim - Pressione Enter");
            Console.ReadKey();
        }

        #region Private Methods

        private static List<Friend> GetFriendsNext(string friendName)
        {
            var friendVisit = friends.Where(p => p.Name == friendName).FirstOrDefault();
            var distance = new GeoDistance();
            return distance.ListFriendsNext(friends, friendVisit);
        }

        private static void DisplayFriends(List<Friend> friends)
        {
            foreach (var item in friends)
            {
                Console.WriteLine("Amigo: " + item.Name);
                Console.WriteLine("Latitude: " + item.FriendAddress.NumberLatitude);
                Console.WriteLine("Longitude: " + item.FriendAddress.NumberLongitude);
                Console.WriteLine("---------------------------------------------------");
            }
        }
             
        #endregion
    }
}
