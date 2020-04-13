using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Priority_Queue;

namespace Busquedas
{
    class CitiesDb
    {
        City oradea = new City("Oradea");
        City zerind = new City("Zerind");
        City arad = new City("Arad");
        City timisoara = new City("Timisoara");
        City lugoj = new City("Lugoj");
        City mehadia = new City("Mehadia");
        City dobreta = new City("Dobreta");
        City craiova = new City("Craiova");
        City sibiu = new City("Sibiu");
        City fagaras = new City("Fagaras");
        City rimnicu = new City("Rimnicu Vilcea");
        City pitesti = new City("Pitesti");
        City bucarest = new City("Bucarest");
        City giurgiu = new City("Giurgiu");
        City urziceni = new City("Urziceni");
        City hirsova = new City("Hirsova");
        City eforie = new City("Eforie");
        City vaslui = new City("Vaslui");
        City iasi = new City("Iasi");
        City neamt = new City("Neamt");

        public TextBlock tbResult;
        public TextBlock tbOrder;

        public CitiesDb()
        {
            KnowledgeCreation();
        }

        public List<City> getCitiesList()
        {
            List<City> totalCities = new List<City>();
            totalCities = new List<City>() { oradea, zerind, arad, timisoara, lugoj
            , mehadia, dobreta, craiova, sibiu, fagaras, rimnicu, pitesti, bucarest, giurgiu, urziceni, hirsova
            , eforie, vaslui, iasi, neamt};
            return totalCities;
        }


        // Busqueda en profundidad 

        public void DFSSearchInterface(City root, City destiny)
        {
            tbResult.Text = "Busqueda en profundidad de: " + root.CityName + " hacia " + destiny.CityName;
            tbOrder.Text = "Orden de busqueda: \n";
            List<City> cities = new List<City>();
            int sum = 0;
            DFSSearch(root, destiny, cities, sum);
        }

        City DFSSearch(City root, City destiny, List<City> cities, int sum)
        {
            String progress = "\n ";
            cities.Add(root);
            if (destiny == root)
            {
                progress += ("Llegue a: " + root.CityName + ", con un costo acumulado de: " + sum);
                tbResult.Text += progress;
                tbOrder.Text += "\n ↓ \n" + root.CityName;
                return root;
            }
            City cityFound = null;
            foreach (var tempCity in root.Rutes)
            {
                if (!cities.Contains(tempCity.DestinationCity))
                {
                    tbOrder.Text += "\n ↓ \n" + root.CityName;
                    progress += ("\n Me encuentro en: " + root.CityName + ", viajare a: " + tempCity.DestinationCity.CityName + ", llevando actualmente un costo acumulado de: " + sum);
                    tbResult.Text += progress;
                    cityFound = DFSSearch(tempCity.DestinationCity, destiny, cities, sum + tempCity.Cost);
                }
                if (cityFound != null)
                    break;
            }
            return cityFound;
        }

        // Atravesar todo el grafo

        public void DFSTraverseInterface(City root)
        {
            tbOrder.Text = "Atravesando el grafo tomando como raiz a : " + root.CityName + "\n";
            List<City> cities = new List<City>();
            DFSTraverse(root, cities);
        }

        void DFSTraverse(City root, List<City> cities)
        {
            tbOrder.Text += "\n ↓ \n" + root.CityName;
            cities.Add(root);

            foreach (var tempCity in root.Rutes)
            {
                if (!cities.Contains(tempCity.DestinationCity))
                {
                    DFSTraverse(tempCity.DestinationCity, cities);
                }
            }
        }


        // Busqueda de costo uniforme
        public void UCSInterface(City root, City destiny)
        {
            tbResult.Text = ("Orden de expansion del arbol de costo uniforme (pretty): \n ");
            tbOrder.Text = (" Orden de expansion sencillo: ");
            List<City> cities = new List<City>();
            UCSearch(root, destiny, cities);
        }
        void UCSearch(City root, City destiny, List<City> cities)
        {
            SimplePriorityQueue<City> Frontier = new SimplePriorityQueue<City>();
            root.PathCost = 0;
            Frontier.Enqueue(root, 0);
            float sum;

            while (Frontier.Count != 0)
            {
                sum = Frontier.GetPriority(Frontier.First);
                City parent = (City)Frontier.Dequeue();
                tbResult.Text += ("\n Expando el nodo de: " + parent.CityName + " Llevando un costo actual de: " + sum);
                tbOrder.Text += ("\n" + parent.CityName + " Costo: " + sum + "\n ↓");
                if (parent == destiny)
                {
                    tbResult.Text += ("\n Llegue al destino con un costo total de: " + sum);
                    break;
                }
                cities.Add(parent);
                foreach (var tempRute in parent.Rutes)
                {
                    if (!cities.Contains(tempRute.DestinationCity))
                    {
                        if (!Frontier.Contains(tempRute.DestinationCity))
                        {
                            Frontier.Enqueue(tempRute.DestinationCity, sum + tempRute.Cost);
                        }else
                        {
                            if (Frontier.GetPriority(tempRute.DestinationCity) > sum + tempRute.Cost)
                            {
                                Frontier.TryUpdatePriority(tempRute.DestinationCity, sum + tempRute.Cost);
                            }
                        }
                    }
                }
            }

        }















        public void KnowledgeCreation()
        {
            List<Rute> rutes = new List<Rute>();
            Rute rute = new Rute(zerind, 71);
            Rute rute1 = new Rute(sibiu, 151);
            rutes.Add(rute); rutes.Add(rute1);
            oradea.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(oradea, 71);
            rute1 = new Rute(arad, 75);
            rutes.Add(rute); rutes.Add(rute1);
            zerind.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(zerind, 75);
            rute1 = new Rute(sibiu, 140);
            Rute rute2 = new Rute(timisoara, 118);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2);
            arad.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(arad, 118);
            rute1 = new Rute(lugoj, 111);
            rutes.Add(rute); rutes.Add(rute1);
            timisoara.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(timisoara, 111);
            rute1 = new Rute(mehadia, 70);
            rutes.Add(rute); rutes.Add(rute1);
            lugoj.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(lugoj, 70);
            rute1 = new Rute(dobreta, 75);
            rutes.Add(rute); rutes.Add(rute1);
            mehadia.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(mehadia, 75);
            rute1 = new Rute(craiova, 120);
            rutes.Add(rute); rutes.Add(rute1);
            dobreta.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(dobreta, 120);
            rute1 = new Rute(rimnicu, 146);
            rute2 = new Rute(pitesti, 138);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2);
            craiova.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(oradea, 151);
            rute1 = new Rute(arad, 140);
            rute2 = new Rute(fagaras, 99);
            Rute rute3 = new Rute(rimnicu, 80);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2); rutes.Add(rute3);
            sibiu.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(sibiu, 99);
            rute1 = new Rute(bucarest, 211);
            rutes.Add(rute); rutes.Add(rute1);
            fagaras.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(sibiu, 80);
            rute1 = new Rute(pitesti, 97);
            rute2 = new Rute(craiova, 146);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2);
            rimnicu.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(rimnicu, 97);
            rute1 = new Rute(craiova, 138);
            rute2 = new Rute(bucarest, 101);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2);
            pitesti.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(fagaras, 211);
            rute1 = new Rute(pitesti, 101);
            rute2 = new Rute(urziceni, 85);
            rute3 = new Rute(giurgiu, 90);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2); rutes.Add(rute3);
            bucarest.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(bucarest, 90);
            rutes.Add(rute);
            giurgiu.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(bucarest, 85);
            rute1 = new Rute(hirsova, 98);
            rute2 = new Rute(vaslui, 142);
            rutes.Add(rute); rutes.Add(rute1); rutes.Add(rute2);
            urziceni.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(urziceni, 98);
            rute1 = new Rute(eforie, 86);
            rutes.Add(rute); rutes.Add(rute1);
            hirsova.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(hirsova, 86);
            rutes.Add(rute);
            eforie.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(urziceni, 142);
            rute1 = new Rute(iasi, 92);
            rutes.Add(rute); rutes.Add(rute1);
            vaslui.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(vaslui, 92);
            rute1 = new Rute(neamt, 87);
            rutes.Add(rute); rutes.Add(rute1);
            iasi.Rutes = rutes;

            rutes = new List<Rute>();
            rute = new Rute(iasi, 87);
            rutes.Add(rute);
            neamt.Rutes = rutes;
        }
    }
}
