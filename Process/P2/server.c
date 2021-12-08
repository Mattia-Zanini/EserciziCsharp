#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <windows.h>

int main(int argc, char *argv[]){
    if(argc != 2){
        printf("Errore negli argomenti");
        exit(1);
    }
    char prodotto[] = "pomodoro";
    int quantita = 300;
    int prezzo = 5;
    if(strcmp(argv[1], prodotto) == 0){
        printf("Qunatita: %d Prezzo: %d", quantita, prezzo);
        exit(0);
    }
    else{
        printf("-1");
        exit(1);
    }
}