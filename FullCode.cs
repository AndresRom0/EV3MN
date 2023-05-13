//DATOS ENTRADA
double[] x1 = { 3, 4 };
double[] y = { 23.5, 30 };

double xA = 1.5, yA = 0;
//Variables del programa
int datos = x1.Length; //Cantidad de elementos en X
double[,] matriz = new double[datos, datos + 1];

//RECORRER MATRIZ (CUADRADA)
for (int i = 0; i < datos; i++) //RENGLONES
{
    for (int j = 0; j < datos; j++) //COLUMNAS
    { //EL PRIMER VALOR DE X SE ELEVA A LA 0 , 1, 2 ,3, 4, 5
        matriz[i, j] = Math.Pow(x1[i], j);
    }
}

//VACIAR EL VECTOR Y EN LA ULTIMA COLUMNA DE LA MATRIZ.
for (int i = 0; i < datos; i++)
{
    matriz[i, datos] = y[i];
}

int ren = datos, col = ren + 1;
//VARIABLES FIJAS
double factor, pivote;

// Recorrer matriz para imprimir datos
for (int r = 0; r < ren; r++) //RECORRER RENGLONES r = 0 -> 1 -> 2
{
    pivote = matriz[r, r];
    for (int c = 0; c < col; c++) //RECORRER COLUMNAS C = 0 
    {
        //   if(matriz[r,c]==0)
        matriz[r, c] = matriz[r, c] / pivote;
        //  matriz[r,c] /= pivote;   
    }
    //VOLVER A RECORRER LA MATRIZ PARA HACER LAS CONVERSIONES A CERO
    for (int rCero = 0; rCero < ren; rCero++)
    {
        if (r != rCero) //BRINCAR EL RENGLON DEL PIVOTE
        {
            factor = matriz[rCero, r];

            for (int cCero = 0; cCero < col; cCero++)
            {
                //(VALOR ORIGINAL ) – (RENGLON DEL PIVOTE,C)(FACTOR))\
                matriz[rCero, cCero] = matriz[rCero, cCero] - (factor * matriz[r, cCero]);
                //matriz[rCero, cCero] -= (factor* matriz[r,cCero]);
            }
        }
    }
}
//imprimir en formar en ecuación
for (int r = 0; r < ren; r++)
{
    if (r < ren - 1)
    {
        Console.WriteLine("La ecuacion de la aceleración de la partícula es: " + matriz[r, col - 1] + "x^" + r + "+");
    }
    else
    {
        Console.WriteLine(matriz[r, col - 1] + "x^" + r);
    }
}
Console.WriteLine("La ecuacion de la Velocidad es 4x+3.25x^2+c");

double limInferior = 5, limSuperior = 10; //VALORES DE ENTRADA
int partes = 1000; //DEFINIR # DE PARTES, ENTRE MAS GRANDE MAS EXACTO
double baseTrapecio, altura1, altura2, area = 0;

//calcular la BASE
baseTrapecio = (limSuperior - limInferior) / partes;

//CICLO PARA CALCULAR AREAS
for (double i = limInferior; i < limSuperior;)
{
    altura1 = 4 * Math.Pow(i, 0) + 6.5 * Math.Pow(i, 1); //ADAPTAR
    i += baseTrapecio;
    altura2 = 4 * Math.Pow(i, 0) + 6.5 * Math.Pow(i, 1); //ADAPTAR
    area += (altura1 + altura2) / 2 * baseTrapecio;
}
Console.WriteLine("La velocidad de la partícula en el intervalo de 5 a 10 minutos es igual a: " + Math.Round(area, 3));
Console.WriteLine("La ecuacion de la Velocidad es 2x^2+3.25x^3+2.5x");

double paso = 0.001, dy, y1 = 0, x = 0, xB = 25;

while (x < xB)
{
    //diferencial
    dy = 4 * x + 3.25 * Math.Pow(x, 2) + 2.5;   //ADAPTAR
                                                      //avanzar la y
    y1 = (dy * paso) + y1; //y += dy * paso; 
                           //avanzar la x
    x += paso; //x = x + paso;
}
Console.WriteLine("La posición de la partícula a los  " + xB + " minutos es igual a es: " + Math.Round(y1, 3));
