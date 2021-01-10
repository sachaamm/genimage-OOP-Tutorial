# genimage-OOP-Tutorial

Projet tutoriel abordant les notions elementaires de la Programmation orientee objet ( [POO](https://fr.wikipedia.org/wiki/Programmation_orient%C3%A9e_objet) ou [OOP](https://en.wikipedia.org/wiki/Object-oriented_programming) en anglais ).

## Scenes

* Blocks : cette scene lance le mini-projet abordant la problematique Minecraft

* Vehicles : cette scene aborde les notions d'heritages de classes et les classes abstraites par un exemple concret

## Histoire de la Programmation Orientée Objet
Lorsqu'on parle de programmation orientée objet, on parle de langages orienté objet, c'est à dire que la notion d'objet est inhérente au langage informatique.
Si on prend l'exemple de Unity, on programme avec un langage informatique, le C# qui est un langage orienté objet. Mais pour parler de langage orienté objet, il est nécessaire de d'abord définir ce qu'est un objet. Qu'est ce qu'un objet en langage informatique ? Pour comprendre ce qu'est un objet en langage informatique il est nécessaire de remonter dans le temps et de revenir en 1979. A l'époque, la programmation est encore rudimentaire et le nombre de langages de programmation disponibles sont bien moins nombreux qu'aujourd'hui. Parmi ces premiers langages, on trouve notamment le C qui est beaucoup utilisé. Un ingénieur américain travaillant chez AT&T du nom de Bjarne Stroustrup travaille sur une fonctionnalité qui était manquante au langage C : les classes ( le projet s'intitulait à la base "C with classes" ). Plus tard, de cette extension émergera le C++. Cette volonté de créer des classes était motivé selon Bjarne Stroustrup à s'inspirer d'autres langages informatiques qui offraient une bibliothèque plus fournie d'outils/fonctionnalités pour les développeurs tels que le langage Simula mais tout en gardant la versatilité du langage C qui était un langage largement utilisé de par sa dimension "bas-niveau" qu'il offrait.

## Programmation fonctionnelle et programmation orientée objet
Aujourd'hui, la programmation orientée objet est présente dans de nombreux langages, une liste exhaustive de ces différents langages serait trop longue. Pour certains d'entre eux la notion de programmation orientée objet est centrale, on pourrait notamment pour d'autres citer Java, C#, C++. Il est courant d'opposer la programmation fonctionnelle à la programmation orientée objet même si certains langages utilisent ces deux paradigmes, on peut citer parmi eux des langages tels que Python, Rust ou encore Go. Ces paradigmes ( orientée objet / fonctionnelle ), font partie de classification de langage de programmation, et au sein d'un langage un paradigme peut être explicitement invoqué ou implicitement induit ( si on prend l'exemple de la programmation fonctionnelle : elle est explicite et mis en avant en Javascript, quand elle est induite en C++ ).

## Qu'est ce qu'un objet
Si on veut parler d'objet en langage informatique, il est nécessaire de parler d'abord de la notion de primitive. Pour parler de la notion de primitive il est nécessaire de parler de la notion de type. 

## Type : type primitif et objet
On peut facilement définir ce qu'est un type via une déclaration de variable. Une déclaration de variable s'effectue ainsi si on reste dans le cadre du langage C#

```cs
int uneVariable;
```
Ma déclaration de variable est effectuée ici par 3 éléments
**int**: le type de ma variable
**uneVariable**: le nom que je donne à cette variable de type int
**;**: le séparateur pour terminer ma déclaration
Ma variable est donc de type int. On distingue les types primitifs des objets. Tout d'abord, laissez moi revenir sur ce qu'est un type primitif. Un type primitif est un 
type élémentaire, c'est à dire que si on fait l'analogie d'un langage informatique à un langage conventionnel, une bonne analogie serait de faire correspondre aux primitifs les lettres d'un langage, quand les objets correspondraient à des mots.
Un mot est composé de lettres, c'est à dire qu'un objet est composé de primitifs, ou de sous objets. Un type primitif est le type le plus élémentaire qui soit, c'est à dire qu'il n'est consitué d'aucun sous objet. 
Voici un exemple de type prmitifs dans le langage C# : 
- **int** : un nombre entier ( ex : -1,0,1,2,3,4... )
- **float** : un nombre à virgule ( ex : 3.14f )
- **byte** : un nombre entier allant de 0 à 255 ( ex : 3 )
- **bool** : un booléen qui correspond à deux statuts possible, vrai ou faux ( ex: true )
- **char** : un caractère ( ex : 'c' )
- **string** : une chaine de caratère ( ex : "Bonjour" )
L'exemple du type primitif string peut être confusant puisqu'une string est une chaîne de caractères, elle est donc une primitive comportant d'autres primitives ! 
En Java par exemple, String est un objet. Pourtant en C#, une string est bien un type primitif. 
A savoir : un type primitif commence toujours par une minuscule. Un objet quant à lui, commence usuellement par une majuscule, et il est fortement déconseillé de définir des objets sans respecter cette règle. La coloration syntaxique de votre IDE ( comme par exemple Visual Studio ) vous permet également via la coloration syntaxique de différencier un type "primitif" d'un objet. 
Si on résume : 
- Les types primitifs sont les types élémentaires, contrairement aux objets qui sont des agglomérats de primitifs / sous-objets.
- Un objet commence par une majuscule quant un type primitif commence par une minuscule
- La coloration syntaxique de certains IDE permettent de distinguer les types primitifs des objets.
- La notion de type regroupe les types primitifs et les objets

## Mon premier objet avec un cas pratique, le type Humain

Je peux donc créer un objet en utilisant le mot clé class
```cs
class Humain {
  string nom;
  int age;
}

Humain toto;
```

Comme on peut le voir, la déclaration d'un objet peut se faire via le mot clé class.
Je viens donc créer une classe que je pourrais utiliser à ma guise. J'ai donc créer ici un nouveau Type intitulé "Humain". Ma classe **Humain** contient deux variables, une variable de type primitif **string** intitulé **"nom"** et une variable de type primitif de type **int** intitulé **"age"**. 
J'ai crée plus bas une variable de type **Humain** avec la classe que j'ai crée, intitulé "toto". On peut donc dire que "toto" est un "Humain". Pour reprendre les analogies, la classe Humain serait donc en quelque sorte un objet représentant une notion abstraite, comme par exemple une carte d'identité. La carte d'identité donne les caractéristiques d'un Humain: nom, age, etc... toto lui, est une personne réelle. Donc une classe est à voir comme un modèle, une structure englobant des caractéristiques regroupées autour d'un ensemble constituant ( ici les caractéristique propres à chaque humain ).

## Le constructeur
Nous nous sommes contentés de déclarer notre variable toto de type **Humain** sans lui assigner de valeur. Nous allons lui assigner maintenant une valeur, et pour cela nous allons déclarer dans la classe un constructeur pour pouvoir assigner une valeur à **toto**.

```cs
class Humain {
  string nom;
  int age;
  
  public Humain(string _nom, int _age){
    nom = _nom;
    age = _age;
  }
}

Humain toto = new Humain("TOTO", 15); // toto a maintenant pour variable nom = "TOTO" et age = à 15
```

Le constructeur est utilisé pour assigner les valeur des variables au sein de notre classe **Humain**. Notez que le constructeur est précédé du mot clé **public** qui nous permet d'appeler le constructeur en dehors de la classe 


## L'utilité de la Programmation Orientée Objet illustré par un cas concret : "la problématique Minecraft"
Nous sommes en droit de nous demander l'utilité de l'approche de la Programmation orientée objet. Nous pouvons aborder l'exemple de la problématique Minecraft. Minecraft est un jeu de type sandbox, où le joueur façonne l'environnement bloc par bloc. Le joueur vient modifier cet environnement de bloc existant, et le jeu doit donc stocker cet environnement de bloc en considérant chaque l'existence de chacun des blocs à une position donnée.

... On aura une méthode pour ajouter un bloc en mettant la valeur du booléen à la position 3D correspondante pour signaler la présence d'un bloc à un endroit



On peut donc considérer cet environnement de blocs enregistré sommairement comme une liste de Vector3

```cs
List<Vector3> blocs = new List<Vector3>(); // Vector3 commence par une majuscule, il ne s'agit pas d'un type primitif !
```
Cette méthode à l'avantage d'être concise et simple à utiliser. Lorsqu'on rajoutera un bloc dans l'environnement, on ajoutera un Vector3 qui correspondra a la position x,y et z du bloc en question.

En revanche, l'utilisation d'un Vector3 n'est pas optimal quand on sait qu'un Vector3 est un objet contenant une position x,y et z flottante. Or, les blocs dans Minecraft sont positionnés sur des valeurs discrètes, ( comme dans une grille ou le nombre de possibilités est restreint, contrairement à un nombre flottant qui peut venir se positionner sur des positions flottantes c'est à dire n'importe ou ). Heureusement il existe pour nous une solution, il s'agit du Vector3Int. 
On aura donc 
```cs
List<Vector3Int> blocs = new List<Vector3Int>(); // Vector3Int commence par une majuscule, il ne s'agit pas d'un type primitif !
```

Pour avoir des performances plus effectives, on peut également utiliser un tableau en plusieurs dimensions plutôt qu'une liste.
On peut donc considérer cet environnement de blocs enregistré comme un tableau de int à 3 dimensions, puisque comme expliqué précedemment les blocs dans Minecraft sont positionnés sur des valeurs discrètes, ( comme dans une grille ou le nombre de possibilités est restreint ).
On pourrait donc résumer les blocs ainsi:
```cs
int worldSideSize = 256;
bool[,,] blocs = new bool [worldSideSize,worldSideSize,worldSideSize];
```

La variable **blocs** est donc un tableau en 3 dimensions, où chaque dimension du tableau enregistre **worldSideSize** valeurs de booléen. 
L'utilisation du booléen détermine la présence ou l'absence d'un bloc à un point. La variable blocs contiendra donc 256 * 256 * 256 possibilités soit un total de
**16777216 entrées**.

Le tableau **blocs** enregistre chaque bloc via un booléen correspondant à la présence ou l'absence d'un bloc à une position 3D ( x,y,z ). On souhaite que par défaut le tableau soit vide, c'est à dire que toutes les valeurs soit égales à false. 
On va donc itérer au sein de ce tableau dans ces 3 dimensions pour initialiser chaque valeur et initialiser la valeur pour la mettre à false.
```cs
for(int x=0; x < worldSideSize; x++){
  for(int x=0; x < worldSideSize; x++){
    for(int x=0; x < worldSideSize; x++){
      blocs[x,y,z] = false;
    }
  }
}
```

Je peux imaginer également une fonction d'ajout de blocs à une position donnée. Supprimer un bloc à une position reviendrait à définir la valeur de l'entrée de blocs à la position x,y,z à false, quand la création de bloc reviendrait à mettre la valeur de cette entrée x,y,z à true.

```cs
void CreateBlockAtPosition(int x, int y, int z){
  blocs[x,y,z] = true;
}

void RemoveBlockAtPosition(int x, int y, int z){
  blocs[x,y,z] = false;
}
```

Imaginons maintenant que je souhaite attribuer une couleur à un bloc, je vais devoir également définir un tableau à 3 dimensions intitulées **blocsColors**
```cs
int worldSideSize = 256;
bool[,,] blocs = new bool[worldSideSize,worldSideSize,worldSideSize];
Color[,,] blocsColors = new Color[worldSideSize,worldSideSize,worldSideSize];
```

J'ai maintenant 2 tableaux à 3 dimensions à gérer parallélement. Un contient l'existence ou non d'un bloc à une position (blocs) et un autre correspond aux couleurs des blocs de mon univers. Ce principe crée plusieurs probèmes et n'est pas une bonne approche pour plusieurs raisons. Je vais devoir gérer en parallèle 2 tableaux et des erreurs peuvent ainsi se produire. Laissez moi illustrer ce principe avec un cas d'usage. 
Je souhaite récupérer la couleur d'un cube à une position pour l'afficher. Mais, suite à un oubli, je n'ai pas encore défini la valeur de la couleur du bloc à cette position. 
Quand j'essaierai d'afficher un cube et d'accéder à sa valeur, je vais donc avoir un NullPointerException.

```cs
Color GetBlocColorAtPos(int x, int y, int z){
  return blocsColors[x,y,z]; 
  // Comme la valeur n'a encore jamais été initialisée, elle renverra sa valeur par défaut, c'est à dire pour ce cas, null...
}
```

Donc si je souhaite afficher une couleur non définie donc nulle, je risque d'avoir des erreurs plus tard.
Je n'ai donc pas obéit à une régle de programmation, **la règle de non-divergence**. Utiliser plusieurs tableaux ou variables pour représenter un même objet ( ici les blocs: leur présence à une position et leur couleur ) doit être **centralisé dans un contexte commun pour éviter de créer de la complexité accidentelle** au sein du code et se trouver dans un stade où des bugs/incohérences se produiront quand certaines variables auront été mises à jour quand d'autres ne l'auront pas été. Cette non centralisation va donc créer une perte de cohérence. (leurs états vont évoluer dans un état différé alors qu'on devait se garantir synchronisé) 
Ce contexte commun va être **un objet que nous allons définir** pour centraliser la complexité. **Et dans cette optique de centralisation de la complexité, la programmation orientée objet va venir à notre rescousse.**

## Illustration





