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
- int : un nombre entier ( ex : -1,0,1,2,3,4... )
- float : un nombre à virgule ( ex : 3.14f )
- byte : un nombre entier allant de 0 à 255 ( ex : 3 )
- bool : un booléen qui correspond à deux statuts possible, vrai ou faux ( ex: true )
- char : un caractère ( ex : 'c' )
- string : une chaine de caratère ( ex : "Bonjour" )
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
Je viens donc créer une classe que je pourrais utiliser à ma guise. J'ai donc créer ici un nouveau Type intitulé "Humain". Usuellement la déclaration d'un objet commence avec une majuscule.  Ma classe **Humain** contient deux variables, une variable de type primitif **string** intitulé **"nom"** et une variable de type primitif de type **int** intitulé **"age"**. 
J'ai crée plus bas une variable de type **Humain** avec la classe que j'ai crée, intitulé "toto". On peut donc dire que "toto" est un "Humain". Pour reprendre les analogies, la classe Humain serait donc en quelque sorte un objet représentant une notion abstraite, comme par exemple une carte d'identité. La carte d'identité donne les caractéristiques d'un Humain: nom, age, etc... toto lui, est une personne réelle. Donc une classe est à voir comme un modèle, une structure englobant des caractéristiques regroupées autour d'un ensemble constituant ( ici les caractéristique propres à chaque humain ).



## L'utilité de la Programmation Orientée Objet illustré par un cas concret : "la problématique Minecraft"

