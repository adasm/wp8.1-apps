using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Model
{
    public class ModelDB : DataContext
    {
        public static string DBConnectionString = "Data Source=isostore:/Database.sdf";

        public ModelDB(string connectionString)
            : base(connectionString)
        { }

        public Table<Student>       Studenci;
        public Table<Kurs>          Kursy;
        public Table<Zaliczenie>    Zaliczenia;
        public Table<Pracownik>     Pracownicy;
    }

    [Table(Name="Studenci")]
    public class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Indeks;
        [Column(CanBeNull = false)]
        public string Imie;
        [Column(CanBeNull = false)]
        public string Nazwisko;
        [Column(CanBeNull = false)]
        public string Plec;
        [Column(CanBeNull = false)]
        public DateTime DataUr;
        [Column(CanBeNull = false)]
        public float SredniaOcen;

        EntitySet<Zaliczenie> _Zaliczenia;
        [Association(Name = "FK_Studenci_Zaliczenia", Storage = "_Zaliczenia", OtherKey = "ZaliczenieId", ThisKey = "Indeks", IsForeignKey = true, DeleteOnNull = false)]
        public EntitySet<Zaliczenie> Zaliczenia;

        //[Column(IsVersion = true)]
        //private Binary _version;
    }

    [Table(Name = "Kursy")]
    public class Kurs
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Kod;
        [Column(CanBeNull = false)]
        public string Nazwa;
        [Column(CanBeNull = true)]
        public uint PracId;

        //EntitySet<Zaliczenie> _Zaliczenia;
        //[Association(Name = "FK_Kursy_Zaliczenia", Storage = "_Zaliczenia", OtherKey = "ZaliczenieId", ThisKey = "Kod", IsForeignKey = true)]
        //public EntitySet<Zaliczenie> Zaliczenia;

        //public EntityRef<Pracownik> _Pracownik;
        //[Association(Name = "FK_Kursy_Pracownik", Storage = "_Pracownik", OtherKey = "PracId", ThisKey = "Kod", IsForeignKey = true)]
        //public Pracownik Pracownik;

        //[Column(IsVersion = true)]
        //private Binary _version;
    }

    [Table(Name = "Zaliczenia")]
    public class Zaliczenie
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ZaliczenieId;
        [Column(CanBeNull = false)]
        public uint Indeks;
        [Column(CanBeNull = false)]
        public uint Kod;
        [Column(CanBeNull = false)]
        public float Ocena;
        [Column(CanBeNull = false)]
        public DateTime Data;

        public EntityRef<Student> _Student;
        [Association(Name = "FK_Zaliczenia_Student", Storage = "_Student", OtherKey = "Indeks", ThisKey = "ZaliczenieId", IsForeignKey = true)]
        public Student Student;

        //public EntityRef<Kurs> _Kurs;
        //[Association(Name = "FK_Zaliczenia_Kurs", Storage = "_Kurs", OtherKey = "Kod", ThisKey = "ZaliczenieId", IsForeignKey = true)]
        //public Kurs Kurs;

        //[Column(IsVersion = true)]
        //private Binary _version;
    }

    [Table(Name = "Pracownicy")]
    public class Pracownik
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int PracId;
        [Column(CanBeNull = false)]
        public string Imie;
        [Column(CanBeNull = false)]
        public string Nazwisko;
        [Column(CanBeNull = false)]
        public string Plec;

        //EntitySet<Kurs> _Kursy;
        //[Association(Name = "FK_Pracownik_Kursy", Storage = "_Kursy", OtherKey = "Kod", ThisKey = "PracId", IsForeignKey = true)]
        //public EntitySet<Kurs> Kursy;

        //[Column(IsVersion = true)]
        //private Binary _version;
    }


    public class Populate
    {
        public static void now(ModelDB db)
        {
            var rnd = new Random();
            var imiona = new string[] { "Henryk", "Jacek", "Adam", "Lukasz", "Marek", "Jozef", "Olaf" };
            var nazwiska = new string[] { "Sienkiewicz", "Jacekiewicz", "Adamowski", "Krolewski", "Ostrozny" };
            for (var i = 0; i < 50; i++)
            {
                db.Studenci.InsertOnSubmit(new Student()
                {
                    //Indeks = rnd.Next(191000, 193999),
                    Imie = imiona[rnd.Next(imiona.Length)],
                    Nazwisko = nazwiska[rnd.Next(nazwiska.Length)],
                    Plec = (rnd.Next() % 2 == 0 ? "M" : "K"),
                    DataUr = new DateTime(rnd.Next(1988, 1994), rnd.Next(1, 13), rnd.Next(1, 29)),
                    SredniaOcen = (float)(2.5 + rnd.NextDouble() * 3.0),
                    Zaliczenia = new EntitySet<Zaliczenie>()
                });
            }

            var nazwy = new string[] { "Analiza matematyczna", "Matematyka", "Fizyka", "Java", "Sieci komputerowe", "Sztuczna inteligencja" };
            foreach (var name in nazwy)
            {
                db.Kursy.InsertOnSubmit(new Kurs()
                {
                    Kod = rnd.Next(100, 999),
                    Nazwa = name,
                });
            }

            db.SubmitChanges();
        }
    }
}
