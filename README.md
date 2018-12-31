# Data-Structure-Project

This project is realised by Thomas Beauchataud

The goal of this project is to realize a self resolve pacman.
The principle of the algorithm is to create and store all possible ways of the pacman in a list of way. A way contain a list and a score (number of coin on the way). We fixe a security distance from monster (here the number is fixed at the half of the minimum size of the matrix). If ways dont cross any monster in security distance cases, we select the way which has the best score and we move the pacman in the first direction of this way direction list. If a way find a monster in the security distance area and the pacman isn't in super mode, we delete all ways which start by the same direction of the way which leads to a monster.
This is the general vision of the algorythm, see demonstration in this video : https://youtu.be/KFt_iebI7hU and explications here : www.youtube.fr


In a first time, we will only be interested in the algorithmic part of the project, so we execute it with a simple matrix 8x8, 1 pacman, and 1 monster.

--> Release Version 1


In a second time we will try the algorithm with the same matrix but with a second monster to check the optimization of the algoythm.

--> Release Version 2


We start to have a lot of function, let's create the environment by himselft.

--> Release Version 3


Now that we have a running algoythm on one type of matrix, let's try on a second one to see if it still work and if the complexity isn't too high. We create a 12x14 algorythm with 3 monsters (which is load automaticaly by the program) and we note that the program takes a while between each movement. So we optimized it.

--> Release Version 4


In the next version we have just created a menu to simplify the execution of the program.

--> Release Version 5


In the next version we joined both matrix (12x14 and 8x8) in the same program. They can be selected in the menu.

--> Release Version 6


In the 7th version we added super coins which sets off the super mode of the pacman.

--> Release Version 7
