using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectList
{
    class Program
    {
        /// <summary>
        /// 
        /// Usuario
        /// -Nombre
        /// -Edad CALCULE
        /// -FechaNacimiento
        /// -Estatura (double)
        /// -Usa Lentes (True - False)
        /// -Genero ('H' o 'M')
        /// 
        /// -Lista de 15 objetos con 6 atribuos con distintos tipos de dato
        /// -Consultar el usuario Hombre mas viejo
        /// -Consultar los usuarios nacidos el mes de septiembre
        /// -El usuario Hombre mas viejo nacido a partir del año 2000
        /// -Promedio de estaura de los hombres
        /// -Persona con el nombre mas largo
        /// -Ordenar los registros por edad y mostrar los 3 de enmedio y el primero y el ultimo
        /// -Obtener cuantos Juan existen
        /// -Usuarios que en su nombre contengan "an", cuantas 'a' tienen. 
        /// -Cuanto dinero tienen los hombres y las mujeres
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            //DateTime.Now - new DateTime(2000, 9, 13)
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { Nombre = "Juan", fechaNacimiento = new DateTime(2000, 9, 13), Estatura = 1.70, Edad = 22, Genero = 'H', usaLentes = true, dinero = 100 });
            
            usuarios.Add(new Usuario { Nombre = "Pedro", fechaNacimiento = new DateTime(2001, 6, 13), Estatura = 1.66, Edad = 15, Genero = 'H', usaLentes = false, dinero = 300 });
            
            usuarios.Add(new Usuario { Nombre = "Carlos", fechaNacimiento = DateTime.Today.AddDays(50), Estatura = 1.50, Edad = 34, Genero = 'H', usaLentes = false, dinero = 500 });
            usuarios.Add(new Usuario { Nombre = "Manuel", fechaNacimiento = new DateTime(1994, 9, 13), Estatura = 1.40, Edad = 31, Genero = 'H', usaLentes = false, dinero = 400 });
            usuarios.Add(new Usuario { Nombre = "Jorge", fechaNacimiento = DateTime.Today.AddDays(-57), Estatura = 1.59, Edad = 21, Genero = 'H', usaLentes = false, dinero = 700 });
            usuarios.Add(new Usuario { Nombre = "Luis", fechaNacimiento = new DateTime(1999, 6, 13), Estatura = 1.86, Edad = 16, Genero = 'H', usaLentes = true, dinero = 200 });
            usuarios.Add(new Usuario { Nombre = "Javier", fechaNacimiento = DateTime.Today.AddDays(-33), Estatura = 1.40, Edad = 31, Genero = 'H', usaLentes = false, dinero = 100 });
            usuarios.Add(new Usuario { Nombre = "Alejandro Juan", fechaNacimiento = DateTime.Today.AddDays(-500), Estatura = 1.80, Edad = 46, Genero = 'H', usaLentes = true, dinero = 900 });


        // usuario Hombre mas viejo
            Usuario usuarioHombreMasViejo = usuarios.OrderBy(x => x.fechaNacimiento).Where(x => x.Genero == 'H' && x.usaLentes == true).FirstOrDefault();
            usuarioHombreMasViejo = (from u in usuarios where u.Genero == 'H' && u.usaLentes == true orderby u.fechaNacimiento select u).FirstOrDefault();
            Console.WriteLine("usuario Hombre mas viejo es " + usuarioHombreMasViejo.Nombre + " de " + usuarioHombreMasViejo.Edad + " años");


        // usuarios nacidos el mes de septiembre
            List<Usuario> usuarioNacidoEnSept = usuarios.FindAll(x => x.fechaNacimiento.Month == 9);
            Console.WriteLine("usuarios nacidos el mes de septiembre son " + usuarioNacidoEnSept.Count);


        // usuario Hombre mas viejo nacido a partir del año 2000
            Usuario usuarioMAsViejoDe2000 = usuarios.OrderBy(x => x.fechaNacimiento).Where(x => x.Genero == 'H' && x.fechaNacimiento.Year == 2000).FirstOrDefault(); //.OrderBy(x => x.fechaNacimiento).Where(x => x.Genero == 'H').FirstOrDefault();
            Console.WriteLine("usuario Hombre mas viejo nacido a partir del año 2000 es " + usuarioMAsViejoDe2000.Nombre);


        // Promedio de estaura de los hombres
            Console.WriteLine("Promedio de estaura de los hombres es " + usuarios.Where(x => x.Genero == 'H').Average(x => x.Edad));


        // Persona con el nombre mas largo
            Usuario nombreMasLargo = usuarios.OrderByDescending(x => x.Nombre.Length).First();
            Console.WriteLine("Persona con el nombre mas largo es " + nombreMasLargo.Nombre);


            // Ordenar los registros por edad y mostrar los 3 de enmedio y el primero y el ultimo
            //Usuario primero = usuarios.OrderBy(x => x.Edad).First();
            //Usuario ultimo = usuarios.OrderBy(x => x.Edad).Last();
            //List<Usuario> ulti = usuarios.OrderBy(x => x.Edad).Skip(6).Take(3).ToList();
            //Console.WriteLine(" los 3 de enmedio son");


            //Console.WriteLine("registros ordenados por edad donde el primero  es " + primero.Nombre + " el ultimo es " + ultimo.Nombre);

            List<Usuario> ed = usuarios.OrderBy(x => x.Edad).ToList();

            Console.WriteLine("registros ordenados por edad donde el primero es " + ed.First().Nombre + " el ultimo es " + ed.Last().Nombre +
               " los 3 de enmedio son :");
            foreach (var item in ed.Skip(6).Take(3).ToList())
            {
                Console.WriteLine(item.Nombre);
            }




            //Obtener cuantos Juan existen
            var cuantosJuan = usuarios.Where(x => x.Nombre.Contains("Juan"));
            Console.WriteLine("los Juan que existen es " + cuantosJuan.Count());



        //Usuarios que en su nombre contengan "an", cuantas 'a' tienen. 
            var cuantosAn = usuarios.Where(x => x.Nombre.ToLower().Contains("an")).ToList();
            Console.WriteLine("Usuarios que en su nombre contengan 'an' son " + cuantosAn.Count() + " y aparecen " + cuantosAn.Count(x => x.Equals('a')) + "a's" );
            foreach (var item in cuantosAn)
            {
                Console.WriteLine(item.Nombre);
            }

            //cuantosAn.Join(
            //    usuarios,
            //    x => x.Nombre.ToLower().Contains("an"),
            //    y => y.Nombre.Count('a'),
            //    (x, y) => new { X = x, Y = y }
            //)


        //var HowMuchMoney = usuarios.GroupBy(c => new { c.Genero }).ToList(); //.Select(x => new ) .ToList();//.Select(g => new { genero = g.Key, dinero = g.Count() });
            var HowMuchMoney = usuarios.GroupBy(c => c.Genero).Select(cl => new Usuario { Genero = cl.First().Genero, dinero = cl.Sum(c => c.dinero) }).ToList();

            foreach (var item in HowMuchMoney)
            {
                //Console.WriteLine(item.Genero);
                Console.WriteLine("el genero " + item.Genero + " tiene " + item.dinero + " dinero");
                Console.WriteLine();
                //if (item.Genero == 'H')
                //    Console.WriteLine("dinero H" + item.dinero);
                //else
                //    usuarios.Sum(x => x.dinero);
            }
           

            //Console.WriteLine("usuarios nacidos el mes de septiembre son " + usrSept);


            //Console.WriteLine("usuario Hombre mas viejo nacido a partir del año 2000 es " + us + " " + "oldest"); //--
            //--




            //Console.WriteLine("Usuarios que en su nombre contengan 'an' son " + cuantosAnCuantasA);

            Console.ReadKey();
        }

        class Usuario {
            public String Nombre { get; set; }
            public int Edad { get; set; }
            //{
            //    get
            //    {
            //        TimeSpan timespan = DateTime.Now - fechaNacimiento;
            //        return timespan.Days;
            //    }
            //    set { }
            //}
            public DateTime fechaNacimiento { get; set; }
            public double Estatura { get; set; }
            public bool usaLentes { get; set; }
            public char Genero { get; set; }
            public int dinero { get; set; }
        }
    }
}
