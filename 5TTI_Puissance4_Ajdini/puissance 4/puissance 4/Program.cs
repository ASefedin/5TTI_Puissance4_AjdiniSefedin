using System;

/*using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbPionsAlligner = 4;
            string[,] grille;
            int colonne;
            int ligne;
            CreationGrille(nbPionsAlligner, out grille, out ligne, out colonne);
            for (int i = 0; i < ligne; i++)
            {
                for (int y = 0; y < colonne; y++)
                {
                    Console.Write(grille[i, y]);
                }
                Console.WriteLine();
            }
        }
        static void CreationGrille(int nbPionsAlligner, out string[,] grille, out int ligne, out int colonne)
        {
            
            Console.WriteLine("Création de la grille:");
            Console.WriteLine();
            ligne = 0;
            colonne = 0;
            
            do
            {
                Console.Write("Veuillez saisir le nombre de ligne \n(nombre >=" + nbPionsAlligner + ") : ");
                ligne = int.Parse(Console.ReadLine());
                
                Console.WriteLine();
                Console.Write("Veuillez saisir le nombre de colonne \n(nombre >= " + nbPionsAlligner + "): ");
                colonne = int.Parse(Console.ReadLine());
                
                Console.WriteLine();
            } while (ligne < nbPionsAlligner || colonne < nbPionsAlligner);
            grille = new string[ligne, colonne];
            for (int i = 0; i < ligne; i++)
            {
                for (int y = 0; y < colonne; y++)
                {
                    grille[i, y] = "|0|";
                }
            }
            
        }
    }
}
*/

/*using System;
namespace testMatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Déclaration et initialisation d'une matrice de taille 3x3
            int[,] matrice = new int[3, 3];
            // Écriture dans la matrice
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Entrez la valeur pour la position [{i}, {j}] : ");
                    matrice[i, j] = int.Parse(Console.ReadLine());
                }
            }
            // Affichage de la matrice
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrice[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
 
 */


namespace AjdiniSefedin
{
    class Program
    {
        /// <summary>
        /// Test si l'utilisateur entre bel et bien un entier et si ce n'est pas le cas il il renvoie le text "Veuillez saisir un entier!"
        /// </summary>
        /// <returns></returns>
        static int TestValiditeDuTypeDeLaSaisie()
        {
            int r;
            while (!int.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Veuillez saisir un entier!");
            }
            return r;
        }


        /// <summary>
        /// demande à l'utilisateur de saisir le nombre de pions qu'il faut aligner pour gagner la partie. Elle s'assure également que l'utilisateur saisit bien un nombre supérieur ou égal à 3. Et ainsi elle prend en consideration le nombre.
        /// </summary>
        /// <returns></returns>
        static int NombreCoupsPourGagner()
        {
            int nombre = 0;
            do
            {
                Console.Write("Veuillez saisir le nombre de pion à aligner pour gagner: \n(nombre >= 3) : ");
                nombre = TestValiditeDuTypeDeLaSaisie();
            } while (nombre < 3);
            return nombre;
        }
        /// <summary>
        /// Je demande a l'utilisateur de saisir le nombre de ligne et de colonne du moment qu'ils sont plus petit que le parametre nbPionsAlligner et ensuite je crée la grille puis avec le return je l'affiche. 
        /// </summary>
        /// <param name="nbPionsAlligner">le nombre de pions a alligner pour gagner </param>
        /// <returns></returns>
        static int[,] CreationGrille(int nbPionsAlligner)
        {

            Console.WriteLine("Création de la grille:");
            Console.WriteLine();
            int ligne = 0;
            int colonne = 0;

            do
            {
                Console.Write("Veuillez saisir le nombre de ligne \n(nombre >=" + nbPionsAlligner + ") : ");
                ligne = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Veuillez saisir le nombre de colonne \n(nombre >= " + nbPionsAlligner + "): ");
                colonne = int.Parse(Console.ReadLine());

                Console.WriteLine();
            } while (ligne < nbPionsAlligner || colonne < nbPionsAlligner);

            int[,] grille = new int[ligne, colonne];
            return grille;
        }

        /// <summary>
        /// test pour voir si l'utilisateur entre une valeur dans la grille correspondant a grille[ligne,colonne] puis regarde la colonne. Si les deux cases de la grille contiennent un pion du joueur, le compteur est incrémenté.
        /// </summary>
        /// <param name="grille">grille déja crée</param>
        /// <param name="ligne">nbLigne du dernier pion placé</param>
        /// <param name="colonne">nbColonne du dernier pion placé</param>
        /// <param name="noJoueur">le joueur qui a placé le dernier pions</param>
        /// <param name="nbCoupsPourGagner">nbPionsAlligner</param>
        /// <returns></returns>
        static bool TestHorizontales(int[,] grille, int ligne, int colonne, int noJoueur, int nbCoupsPourGagner)
        {
            bool test = false;
            int compteur = 0;
            for (int i = 0; i < nbCoupsPourGagner; ++i)
            {
                if (grille[ligne, colonne] == noJoueur && grille[ligne, colonne + i] == noJoueur)
                {
                    ++compteur;
                }
            }
            if (compteur == nbCoupsPourGagner)
            {
                test = true;
            }
            return test;
        }
        /// <summary>
        /// test pour voir si l'utilisateur entre une valeur dans la grille correspondant a grille[ligne,colonne]puis regarde la ligne. Si les deux cases de la grille contiennent un pion du joueur, le compteur est incrémenté.
        /// </summary>
        /// <param name="grille">grille déja crée</param>
        /// <param name="ligne">nbLigne du dernier pion placé</param>
        /// <param name="colonne">nbColonne du dernier pion placé</param>
        /// <param name="noJoueur">le joueur qui a placé le dernier pions</param>
        /// <param name="nbCoupsPourGagner">nbPionsAlligner</param>
        /// <returns></returns>
        static bool TestVertical(int[,] grille, int ligne, int colonne, int noJoueur, int nbCoupsPourGagner)
        {
            bool test = false;
            int compteur = 0;
            for (int i = 0; i < nbCoupsPourGagner; ++i)
            {
                if (grille[ligne, colonne] == noJoueur && grille[ligne - i, colonne] == noJoueur)
                {
                    ++compteur;
                }
            }
            if (compteur == nbCoupsPourGagner)
            {
                test = true;
            }
            return test;
        }
        /// <summary>
        /// test si un joueur a aligné nbCoupsPourGagner pions diagonalement de gauche à droite, en partant de la position [ligne, colonne] de la grille.
        /// </summary>
        /// <param name="grille">grille déja crée</param>
        /// <param name="ligne">nbLigne du dernier pion placé</param>
        /// <param name="colonne">nbColonne du dernier pion placé</param>
        /// <param name="noJoueur">le joueur qui a placé le dernier pions</param>
        /// <param name="nbCoupsPourGagner">nbPionsAlligner</param>
        /// <returns></returns>
        static bool TestDiagoGaucheDroite(int[,] grille, int ligne, int colonne, int noJoueur, int nbCoupsPourGagner)
        {
            bool test = false;
            int compteur = 0;
            for (int i = 0; i < nbCoupsPourGagner; ++i)
            {
                if (grille[ligne, colonne] == noJoueur && grille[ligne - i, colonne + i] == noJoueur)
                {
                    ++compteur;
                }
            }
            if (compteur == nbCoupsPourGagner)
            {
                test = true;
            }
            return test;
        }
        /// <summary>
        /// test si un joueur a aligné nbCoupsPourGagner pions diagonalement de droite à gauche, en partant de la position [ligne, colonne] de la grille.
        /// </summary>
        /// <param name="grille">grille déja crée</param>
        /// <param name="ligne">nbLigne du dernier pion placé</param>
        /// <param name="colonne">nbColonne du dernier pion placé</param>
        /// <param name="noJoueur">le joueur qui a placé le dernier pions</param>
        /// <param name="nbCoupsPourGagner">nbPionsAlligner</param>
        /// <returns></returns>
        static bool TestDiagoDroiteGauche(int[,] grille, int ligne, int colonne, int noJoueur, int nbCoupsPourGagner)
        {
            bool test = false;
            int compteur = 0;
            for (int i = 0; i < nbCoupsPourGagner; ++i)
            {
                if (grille[ligne, colonne] == noJoueur && grille[ligne - i, colonne - i] == noJoueur)
                {
                    ++compteur;
                }
            }
            if (compteur == nbCoupsPourGagner)
            {
                test = true;
            }
            return test;
        }
        /// <summary>
        /// vérifie si le numéro de colonne fourni est valide pour être joué dans la grille donnée.
        /// </summary>
        /// <param name="colonne">le numéro de colonne qui doit être testé</param>
        /// <param name="grille">la grille dans laquelle la colonne doit être testée</param>
        /// <returns></returns>
        static bool TestNumColonneValide(int colonne, int[,] grille)
        {
            bool test = false;
            if (colonne > 0 && colonne <= grille.GetLength(1) && !ColonnePleine(grille, colonne))
            {
                test = true;
            }
            return test;
        }
        /// <summary>
        ///  permet de demander à l'utilisateur de saisir un numéro de colonne valide pour placer un pion dans la grille, elle lui demande de saisir une donnée valide tant que la colonne tester est fausse.
        /// </summary>
        /// <param name="grille"></param>
        /// <returns></returns>
        static int SaisirUnNumColonneValide(int[,] grille)
        {
            int numColonne = 0;
            do
            {
                Console.Write("Veuillez saisir une colonne valide: ");
                numColonne = TestValiditeDuTypeDeLaSaisie();
                Console.WriteLine();
            } while (!TestNumColonneValide(numColonne, grille));
            return numColonne;
        }
        /// <summary>
        /// 1) colonnePleine = false, si la case du haut de la colonne contient un pion du joueur 1 ou du joueur 2. Si c'est le cas, cela signifie que la colonne est pleine, car tous les pions doivent être placés en bas de la colonne et la case du haut ne peut pas être vide. Si la case du haut est vide, la colonne n'est pas pleine.
        /// </summary>
        /// <param name="grille">affichage grille </param>
        /// <param name="colonne">colonne en question</param>
        /// <returns></returns>
        static bool ColonnePleine(int[,] grille, int colonne)
        {
            bool colonnePleine = false;

            if (grille[0, colonne - 1] == 1 || grille[0, colonne - 1] == 2)
            {
                colonnePleine = true;
            }
            return colonnePleine;
        }
        /// <summary>
        /// teste si un joueur a gagné horizontalement en vérifiant chaque case de la grille dans les rangées en partant de la dernière rangée jusqu'à la première et pour chaque colonne
        /// </summary>
        /// <param name="grille">semblable a grille[ligne,colonne]</param>
        /// <param name="numJoueur">il s'agit du numéro du joueur dont on veut tester s'il a gagné.</param>
        /// <param name="nbCoupsVictoire">nbPionsAlligner</param>
        /// <returns></returns>
        static bool VictoireHorizontale(int[,] grille, int numJoueur, int nbCoupsVictoire)
        {
            bool victoireHorizontale = false;
            for (int i = grille.GetLength(0) - 1; i >= 0; --i)
            {
                for (int j = 0; j < grille.GetLength(1) - (nbCoupsVictoire - 1); ++j)
                {
                    bool testHorizontal = TestHorizontales(grille, i, j, numJoueur, nbCoupsVictoire);
                    if (testHorizontal)
                    {
                        victoireHorizontale = true;
                    }
                }
            }
            return victoireHorizontale;
        }
        /// <summary>
        /// teste si un joueur a gagné diagonalement de gauche à droite  en vérifiant chaque case de la grille dans les rangées en partant de la dernière rangée jusqu'à la première et pour chaque colonne.
        /// </summary>
        /// <param name="grille">semblable a grille[ligne,colonne]</param>
        /// <param name="numJoueur">il s'agit du numéro du joueur dont on veut tester s'il a gagné.</param>
        /// <param name="nbCoupsVictoire">nbPionsAlligner</param>
        /// <returns></returns>
        static bool VictoireDiagonaleGaucheDroite(int[,] grille, int numJoueur, int nbCoupsVictoire)
        {
            bool victoireDiagonaleGaucheDroite = false;
            for (int i = grille.GetLength(0) - 1; i >= (nbCoupsVictoire - 1); --i)
            {
                for (int j = 0; j < grille.GetLength(1) - (nbCoupsVictoire - 1); ++j)
                {
                    bool testDiagoGaucheDroite = TestDiagoGaucheDroite(grille, i, j, numJoueur, nbCoupsVictoire);
                    if (testDiagoGaucheDroite)
                    {
                        victoireDiagonaleGaucheDroite = true;
                    }
                }
            }
            return victoireDiagonaleGaucheDroite;
        }
        /// <summary>
        /// teste si un joueur a gagné diagonalement de droite à gauche  en vérifiant chaque case de la grille dans les rangées en partant de la dernière rangée jusqu'à la première et pour chaque colonne.
        /// </summary>
        /// <param name="grille">semblable a grille[ligne,colonne]</param>
        /// <param name="numJoueur">il s'agit du numéro du joueur dont on veut tester s'il a gagné.</param>
        /// <param name="nbCoupsVictoire">nbPionsAlligner</param>
        /// <returns></returns>
        static bool VictoireDiagonaleDroiteGauche(int[,] grille, int numJoueur, int nbCoupsVictoire)
        {
            bool victoireDiagonaleDroiteGauche = false;
            for (int i = grille.GetLength(0) - 1; i >= (nbCoupsVictoire - 1); --i)
            {
                for (int j = grille.GetLength(1) - 1; j >= (nbCoupsVictoire - 1); --j)
                {
                    bool testDiagoDroiteGauche = TestDiagoDroiteGauche(grille, i, j, numJoueur, nbCoupsVictoire);
                    if (testDiagoDroiteGauche)
                    {
                        victoireDiagonaleDroiteGauche = true;
                    }
                }
            }
            return victoireDiagonaleDroiteGauche;
        }
        /// <summary>
        ///  Elle parcourt les cellules de la grille en commençant par la ligne du bas jusqu'à la ligne correspondant à la hauteur nécessaire pour gagner.
        /// </summary>
        /// <param name="grille">semblable a grille[ligne,colonne]</param>
        /// <param name="numJoueur">il s'agit du numéro du joueur dont on veut tester s'il a gagné.</param>
        /// <param name="nbCoupsVictoire">nbPionsAlligner</param>
        /// <returns></returns>
        static bool VictoireVerticale(int[,] grille, int numJoueur, int nbCoupsVictoire)
        {
            bool victoireVerticale = false;
            for (int i = grille.GetLength(0) - 1; i >= (nbCoupsVictoire - 1); --i)
            {
                for (int j = 0; j < grille.GetLength(1); ++j)
                {
                    bool testVertical = TestVertical(grille, i, j, numJoueur, nbCoupsVictoire);
                    if (testVertical)
                    {
                        victoireVerticale = true;
                    }
                }
            }
            return victoireVerticale;
        }

        /// <summary>
        /// vérifie si la grille est remplie,  Elle parcourt chaque colonne de la première ligne de la grille et vérifie si chaque case contient soit un jeton du joueur 1 soit un jeton du joueur 2.
        /// </summary>
        /// <param name="grille">grille finale</param>
        /// <returns></returns>
        static bool Egalite(int[,] grille)
        {
            bool egalite = true;
            int ligne = 0;
            for (int colonne = 0; colonne < grille.GetLength(1); ++colonne)
            {
                if (grille[ligne, colonne] != 1 && grille[ligne, colonne] != 2)
                {
                    egalite = false;
                }
            }
            return egalite;
        }
        /// <summary>
        /// elle a pour but de vérifier si le joueur passé en paramètre a gagné la partie en appelant différentes fonctions de vérification de victoire (horizontale, verticale, diagonale droite-gauche et diagonale gauche-droite). Si l'une de ces fonctions retourne true, la fonction Victoire retourne true, sinon elle retourne false.
        /// </summary>
        /// <param name="grille">semblable a grille[ligne,colonne]</param>
        /// <param name="numJoueur">il s'agit du numéro du joueur dont on veut tester s'il a gagné.</param>
        /// <param name="nbCoupsVictoire">nbPionsAlligner</param>
        /// <returns></returns>
        static bool Victoire(int[,] grille, int numJoueur, int nbCoupsVictoire)
        {
            bool partieTerminee = false;

            if (VictoireHorizontale(grille, numJoueur, nbCoupsVictoire) ||
                VictoireVerticale(grille, numJoueur, nbCoupsVictoire) ||
                VictoireDiagonaleDroiteGauche(grille, numJoueur, nbCoupsVictoire) ||
                VictoireDiagonaleGaucheDroite(grille, numJoueur, nbCoupsVictoire))
            {
                partieTerminee = true;
            }
            return partieTerminee;
        }
        /// <summary>
        /// elle prend en entrée la grille[ligne,colonne], et retourne true si la position dans la grille spécifiée par la ligne et la colonne est valide
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="ligne"></param>
        /// <param name="colonne"></param>
        /// <returns></returns>
        static bool PositionValide(int[,] grille, int ligne, int colonne)
        {
            bool test = false;
            if (ligne >= 0 && ligne <= grille.GetLength(0) &&
                colonne >= 0 && colonne <= grille.GetLength(1) &&
                (grille[ligne, colonne] != 1 && grille[ligne, colonne] != 2))
            {
                test = true;
            }
            return test;
        }
        /// <summary>
        /// modifie la grille de jeu en ajoutant un pion pour le joueur en cours dans la colonne spécifiée. Elle ressort true si la modification a eu lieu, sinon elle ressort false
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="colonne"></param>
        /// <param name="noJoueur"></param>
        /// <returns></returns>
        static bool ModifierGrille(int[,] grille, int colonne, int noJoueur)
        {
            int num = 0;
            if (noJoueur == 1)
            {
                num = 1;
            }
            else
            {
                num = 2;
            }
            bool modificationReussie = false;
            int i = grille.GetLength(0) - 1;

            while (i >= 0 && !modificationReussie)
            {
                if (PositionValide(grille, i, colonne))
                {
                    grille[i, colonne] = num;
                    modificationReussie = true;
                }
                --i;
            }
            return modificationReussie;
        }
        /// <summary>
        /// couleur
        /// </summary>
        public static ConsoleColor ForegroundColor { get; set; }
        [System.STAThreadAttribute()]

        static void Main(string[] args)
        {
            bool recommencer = true;
            while (recommencer)
            {

                int nbPionsAlligner = 4;
                int colonne;

                int nbCoupsVictoire = NombreCoupsPourGagner();
                Console.Clear();

                int[,] grille = CreationGrille(nbPionsAlligner);
                Console.Clear();


                int noJoueur = 2;

                bool victoire = false;
                bool egalite = false;

                while (!Victoire(grille, noJoueur, nbCoupsVictoire) && !Egalite(grille))
                {
                    noJoueur = (noJoueur % 2) + 1;
                    Console.Clear();
                    AffichageGrille(grille.GetLength(1), grille.GetLength(0), grille);

                    Console.WriteLine("C'est au tour du joueur " + noJoueur);

                    colonne = SaisirUnNumColonneValide(grille);
                    ModifierGrille(grille, colonne - 1, noJoueur);

                    victoire = Victoire(grille, noJoueur, nbCoupsVictoire);
                    egalite = Egalite(grille);

                    Console.WriteLine();
                }
                Console.Clear();
                AffichageGrille(grille.GetLength(1), grille.GetLength(0), grille);
                if (victoire)
                {
                    Console.WriteLine("Le joueur " + noJoueur + " a gagné!");
                }
                else if (egalite)
                {
                    Console.WriteLine("Egalité!");
                }

                Console.Write("Voulez-vous recommencer ? (oui/non) : ");
                string saisie = Console.ReadLine().ToLower();

                while (saisie != "oui" && saisie != "non")
                {
                    Console.WriteLine("Veuillez saisir 'oui' ou 'non' !");
                    Console.Write("Voulez-vous recommencer ? (oui/non) : ");
                    saisie = Console.ReadLine().ToLower();
                }

                if (saisie == "non")
                {
                    recommencer = false;
                }
            }
            /// <summary>
            ///  un rond rouge pour le joueur 1, un rond jaune pour le joueur 2, ou un espace vide pour une case vide
            /// </summary>
            /// <param name="colonne"></param>
            /// <param name="ligne"></param>
            /// <param name="grille">css de la grille</param>
            static void AffichageGrille(int ligne, int colonne, int[,] grille)
            {
                for (int i = 0; i < ligne; i++)
                {
                    for (int y = 0; y < colonne; y++)
                    {
                        Console.Write("+---");
                    }
                    Console.WriteLine("+");
                    if (i != ligne)
                    {
                        for (int y = 0; y < colonne; y++)
                        {
                            Console.Write("| ");
                            if (grille[i, y] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("O ");
                            }
                            else if (grille[i, y] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("O ");
                            }
                            else
                            {
                                Console.Write("  ");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine("|");
                    }
                }
                for (int i = 0; i < colonne; i++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
                Console.WriteLine();
                string chaine = "";
                for (int i = 1; i < grille.GetLength(1) + 1; i++)
                {
                    chaine += "  " + i + " ";
                }
                Console.WriteLine(chaine);
            }
        }
    }
}