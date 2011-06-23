using System;
using System.Drawing;
using System.Windows.Forms;

public class element_big
{
    public enum klocek {I, kwadrat, podium, L, L_revers, Z, Z_revers};

    public bool[,] tablica;
    public klocek ktory;
    public Color kolor;
    public int kat;
    private static Random losuj = new Random();

    public element_big()
    {
        kat = 0;
        tablica = new bool[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                tablica[i, j] = false;
        klocek nowy_element_big = (klocek)losuj.Next(7);
        switch (nowy_element_big)
        {   
            case klocek.I: tablica[0, 0] = tablica[0, 1] = tablica[0, 2] = tablica[0, 3] = true;
                ktory = klocek.I;
                kolor = Color.LawnGreen;
                break; 
            case klocek.kwadrat: tablica[0, 0] = tablica[0, 1] = tablica[1, 0] = tablica[1, 1] = true;
                ktory = klocek.kwadrat;
                kolor = Color.Red;
                break;
            case klocek.podium: tablica[1, 0] = tablica[1, 1] = tablica[2, 1] = tablica[0, 1] = true;
                ktory = klocek.podium;
                kolor = Color.Blue;
                break;
           case klocek.L: tablica[0, 0] = tablica[0, 1] = tablica[0, 2] = tablica[1, 2] = true;
                ktory = klocek.L;
                kolor = Color.Fuchsia;
                break;
            case klocek.L_revers: tablica[1, 0] = tablica[1, 1] = tablica[1, 2] = tablica[0, 2] = true;
                ktory = klocek.L_revers;
                kolor = Color.Yellow;
                break;
            case klocek.Z: tablica[0, 0] = tablica[0, 1] = tablica[1, 1] = tablica[1, 2] = true;
                ktory = klocek.Z;
                kolor = Color.Sienna;
                break;
            case klocek.Z_revers: tablica[1, 0] = tablica[1, 1] = tablica[0, 1] = tablica[0, 2] = true;
                ktory = klocek.Z_revers;
                kolor = Color.Turquoise;
                break;
        }
    }

    public element_big obroc(int alfa)
    {
        if (alfa != 0 && alfa != 90 && alfa != 180 && alfa != 270) 
            return this;
        element_big nowy = new element_big();
        nowy.kat = alfa;
        nowy.kolor = kolor;
        nowy.ktory = ktory;
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                nowy.tablica[i, j] = false;
        switch (ktory)
        {
            case klocek.I:
                switch (alfa)
                {
                    case 0: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[0, 2] = nowy.tablica[0, 3] = true; break;
                    case 180: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[0, 2] = nowy.tablica[0, 3] = true; break;
                    case 90: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[2, 0] = nowy.tablica[3, 0] = true; break;
                    case 270: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[2, 0] = nowy.tablica[3, 0] = true; break;
                }
                break;

            case klocek.kwadrat:
                    nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[0, 1] = nowy.tablica[1, 1] = true; break;

            case klocek.podium:
                switch (alfa)
                {
                    case 0: nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[0, 1] = nowy.tablica[2, 1] = true; break;
                    case 90: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[0, 2] = nowy.tablica[1, 1] = true; break;
                    case 180: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[2, 0] = nowy.tablica[1, 1] = true; break;
                    case 270: nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[0, 1] = nowy.tablica[1, 2] = true; break;
                }
                break;

            case klocek.L:
                switch (alfa)
                {
                    case 0: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[0, 2] = nowy.tablica[1, 2] = true; break;
                    case 90: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[0, 1] = nowy.tablica[2, 0] = true; break;
                    case 180: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[1, 2] = true; break;
                    case 270: nowy.tablica[0, 1] = nowy.tablica[2, 0] = nowy.tablica[1, 1] = nowy.tablica[2, 1] = true; break;
                }
                break;

            case klocek.L_revers:
                switch (alfa)
                {
                    case 0: nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[1, 2] = nowy.tablica[0, 2] = true; break;
                    case 90: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[1, 1] = nowy.tablica[2, 1] = true; break;
                    case 180: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[1, 0] = nowy.tablica[0, 2] = true; break;
                    case 270: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[2, 0] = nowy.tablica[2, 1] = true; break;
                }
                break;

            case klocek.Z:
                switch (alfa)
                {
                    case 0: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[1, 1] = nowy.tablica[1, 2] = true; break;
                    case 180: nowy.tablica[0, 0] = nowy.tablica[0, 1] = nowy.tablica[1, 1] = nowy.tablica[1, 2] = true; break;
                    case 90: nowy.tablica[1, 0] = nowy.tablica[0, 1] = nowy.tablica[2, 0] = nowy.tablica[1, 1] = true; break;
                    case 270: nowy.tablica[1, 0] = nowy.tablica[0, 1] = nowy.tablica[2, 0] = nowy.tablica[1, 1] = true; break;
                }
                break;

            case klocek.Z_revers:
                switch (alfa)
                {
                    case 0: nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[0, 1] = nowy.tablica[0, 2] = true; break;
                    case 180: nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[0, 1] = nowy.tablica[0, 2] = true; break;
                    case 90: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[2, 1] = true; break;
                    case 270: nowy.tablica[0, 0] = nowy.tablica[1, 0] = nowy.tablica[1, 1] = nowy.tablica[2, 1] = true; break;
                }
                break;
        }
        return nowy;
    }
}