using System;
using System.Text;
using System.IO;
// define enum types 

enum Color
{
    red, white, black
}

enum UserName
{
    Marc , 
    Edith, 
    Eugene,
}

delegate void PrintDelegate(string text);
// for print file 

class HelloWord
{
    
     //string[] args : utilise pour passer des arguments en ligne de commande lors de l'execution du programme 
     
     
    static void MainHello(string[ ] args)
    {
        double sum = 24 + 14;
        char a = 'a';
        bool true_false = true;

        if (true_false) {
            Console.WriteLine("il est rentré dans la boucle "); 
            Console.WriteLine(sum);
            Console.WriteLine(a);
        }       
    }
}


// Enum types 
//  ecrire un programme qui permet d'afficher les couleurs rouge, blanche ,noire fonction des noms suivants sachant que M = rouge , E = blanche , Z = noire 

class TestEnumType
{
    static void ColorWithName(Color color ,UserName username )
    {
        switch (color)
        {
            case Color.red:
                Console.WriteLine("cette couleur est " + color + " et elle est pour " + username);  ;
                break;
            case Color.white:
                Console.WriteLine("cette couleur est " + color, " et elle est pour "+ username);
                break;
            case Color.black:
                Console.WriteLine("cette couleur est " + color + " et elle est pour " + username);
                break;

            default:
                Console.WriteLine(double.NaN);
                break;
        }
    }

    static void MainColor(string[] args)
    {
        Color b = Color.black;
        UserName u = UserName.Eugene;
        ColorWithName(b, u);

    }
}

//  Struct types  With Tuples 

struct Point
{
    public double x; 
    public int y;  // 

    // declaration du constructeur 
    public Point(double x, int y)
    {
        this.x = x; // this pour faire référence aux objets champs  de la structure Point afin de les initaliser  avec les valeurs passés en paramètres.
        this.y = y;
    }

    static void MainPoint(string[] args)
    {
        Point p = new Point(4.5, 3);
        //Point p = new(4.5, 3);
        //(double item1, int item2) = (p.x, p.y); // valeur destructurer 

        (double item1, int item2 ) t1 = (p.x, p.y);
        Console.WriteLine($"Tuple with elements {t1.item1} elements is {t1.item2}");
        //Console.WriteLine($"Tuple with elements {item1} elements is {item2}");
    }
}

// study null type 
struct IsNaN
{
    public int? x;
    public int? y; 

    public IsNaN(int? x, int? y) // le constructeur doit avoir le même non que la declaration de class
    {
        this.x = x; 
        this.y = y;
    }

    static void MainIsNaN(string[] args)
    {
        IsNaN n = new IsNaN();  

        n.x = null;
        //(int? item1, int? item2) t1 = (4, 8);
        Console.WriteLine("ikhela"); 
        Console.WriteLine($"{n.x}"); // C'est le comportement normal , le type nullable donne une chaine vide dans la console.log(
        Console.WriteLine($"{n.y.HasValue}");
    }
}


// String type
class ActuUser
{
    public string user;
    public int age;
    
    // defenis un constructeur 
    public ActuUser(string user, int age)
    {
        this.user = user; //  this permet de lever l'ambiguüté entre les noms de paramètres et les noms de champs de classe.
        this.age = age;
    }

    // definition des methode 

    public string FormatString(string user)  // tu n' a pas ajouter le type de retour
    {
        string FormatUser = string.Format("Check Check, {0}", user);
        return FormatUser  ;
    }
    

    // Date & Formatting string
    public string DateString(string user, DateTime DateUser)
    {

        string date_string = $"Chez {user} il est ${DateUser:hh:mm, dd MM yyyy}";
        //string date_string = $"Chez {user} ill est ${DateUser.ToString("hh:mm, dd MM yyyy")}";
        return date_string;
    }

    // String Builder 
    public string StringBuilderUsing(string user)
    {
        StringBuilder sb = new StringBuilder();
        // StringBuilder sb = new(); 
        // Clear supprime tous les caractères d'une instance StringBuilder 
        // Length donne la longueur de la chaîne 
        // Replace("Hello", "Hi") rempalce Hello par Hi 
        // Insert(2, " Word") ajouter word à la deuxième position de l'instance
        // Remove(6, 5) ; supprimer toutes les lettres specifié dans cet intervalle
        // indexOf("t") // retourne la position de l'index
        // Contains // utiliser pour savoir si telle chaîne de string est contenu dans une autre 
        // Substring(2,3) est utilisé pour retourner une partie spécifique de la chaîne de caractère  
        sb.Append("Bonjour Mr");
        sb.Append($" je suis {user}");
        sb.Append(" On se fait un spa");

        return sb.ToString(); 
    }
}

// delegate type



class Program
{
    static void Main(string[] args)
    {
        // ActuUser actu = new ActuUser("Marc", 14);
        // Console.WriteLine($" {actu.FormatString(actu.user)}"); 
        // Console.WriteLine($" {actu.DateString(actu.user , new DateTime())}");
        // Console.WriteLine($" {actu.StringBuilderUsing(actu.user)}");
        // instancier un delegate type 
        
        // avec une farrow fucntion 
        PrintDelegate PrintToFile = (string text) =>
        {
            File.AppendAllText("C:\\Users\\Administrateur\\source\\repos\\c_sharp_net\\log.txt", text);
        };

        PrintDelegate PrintToConsole = (string text) =>
        {
            Console.WriteLine($"{text}");
        };

        string ConnectToDatabase(PrintDelegate log)
        {
            log("Inserting a new record in database");

            log("Isertion done");

            return "insert réussie";
        }

        ConnectToDatabase(PrintToFile);
    }
}