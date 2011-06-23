using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Media;
using System.Diagnostics;

public class Plansza : graj
{
    private int polozenie_x, polozenie_y;
    private element_big klocek;

    public Plansza()
    {
        polozenie_x = polozenie_y = 0;
    }

    public Plansza(int a, int b)
        : base(a, b)
    {
        polozenie_x = polozenie_y = 0;
    }

    public bool rysujklocek(int x, int y, element_big f)
    {
        if (!sprawdz(x, y)) 
            return false;
        int i, j;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                if (f.tablica[i, j])
                {
                    if (!sprawdz(x + i, y + j)) 
                        return false;
                    if (tablica[x + i, y + j].spr()) 
                        return false;
                }
        polozenie_x = x;
        polozenie_y = y;
        if (klocek != f) klocek = f;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                if (f.tablica[i, j])
                {
                    tablica[x + i, y + j].setkolor(f.kolor);
                    rysuj(x + i, y + j);
                }
        return true;
    }

    public bool wlewo()
    {
        if (klocek == null) 
            return false;
        int i, j;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
            {  if (klocek.tablica[i, j] && (i == 0 || !klocek.tablica[i - 1, j]))
                {
                    if (!sprawdz(polozenie_x + i - 1, polozenie_y + j)) 
                        return false;
                    if (tablica[polozenie_x + i - 1, polozenie_y + j].spr()) 
                        return false;
                }
            }

        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                if (klocek.tablica[i, j]) tablica[polozenie_x + i, polozenie_y + j].usun(w, BackColor);
        rysujklocek(polozenie_x - 1, polozenie_y, klocek);
        return true;
    }

    public bool wprawo()
    {
        if (klocek == null) 
            return false;
        int i, j;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
            {
                if (klocek.tablica[i, j] && (i == 3 || !klocek.tablica[i + 1, j]))
                {
                    if (!sprawdz(polozenie_x + i + 1, polozenie_y + j)) 
                        return false;
                    if (tablica[polozenie_x + i + 1, polozenie_y + j].spr()) 
                        return false;
                }
            }

        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                if (klocek.tablica[i, j]) tablica[polozenie_x + i, polozenie_y + j].usun(w, BackColor);
        rysujklocek(polozenie_x + 1, polozenie_y, klocek);
        return true;
    }

    public bool wdol()
    {
        if (klocek == null) 
            return false;
        int i, j;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
            {
                if (klocek.tablica[i, j] && (j == 3 || !klocek.tablica[i, j + 1]))
                {
                    if (!sprawdz(polozenie_x + i, polozenie_y + j + 1)) 
                        return false;
                    if (tablica[polozenie_x + i, polozenie_y + j + 1].spr()) 
                        return false;
                }
            }

        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                if (klocek.tablica[i, j]) tablica[polozenie_x + i, polozenie_y + j].usun(w, BackColor);
        rysujklocek(polozenie_x, polozenie_y + 1, klocek);
        return true;
    }

    public void wyczysc(int n)
    {
        if (!sprawdz(1, n)) 
            return;
        for (int i = 0; i < szerokosc; i++)
            tablica[i, n].usun(w, BackColor);
     }

    public void przesun(int ile)
    {
        if (ile < 0 || ile >= wysokosc - 1) 
            return;
        int i;
        for (i = 0; i < szerokosc; i++)
        {
            if (!tablica[i, ile].spr())
            {
                tablica[i, ile + 1].usun(w, BackColor);
                continue;
            }
            tablica[i, ile].usun(w, BackColor);
            tablica[i, ile + 1].setkolor(tablica[i, ile].getkolor());
            tablica[i, ile + 1].wyswietl(w);
        }
    }

    public int linie()
    {
        int ile = wysokosc - 1;
        int i;
        int liczba = 0;
        bool linia = true;
        while (ile > 0 && liczba < 4)
        {
            for (i = 0; i < szerokosc; i++)
                if (!tablica[i, ile].spr()) 
                    linia = false;
            if (linia)
            {
                liczba++;
                for (int k = ile - 1; k >= 0; k--)
                    przesun(k);
                Assembly assembly;
                SoundPlayer dzwiek;
                assembly = Assembly.GetExecutingAssembly();
                dzwiek = new SoundPlayer(assembly.GetManifestResourceStream("projekt.bridge2.wav"));
                dzwiek.Play();
            }
            else ile--;
            linia = true;
        }
        return liczba;
    }

    public element_big getelement()
    {
        return klocek;
    }
    
   public void obroc()
    {
        if (klocek.kat == 270) klocek.kat = 0;
        else klocek.kat += 90;
        element_big nowy = klocek.obroc(klocek.kat);
        int i, j;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
            {
                if (nowy.tablica[i, j] && !sprawdz(polozenie_x + i, polozenie_y + j)) 
                    return;
                if (nowy.tablica[i, j] && !klocek.tablica[i, j] && tablica[polozenie_x + i, polozenie_y + j].spr())
                    return;
            }

        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                if (klocek.tablica[i, j]) tablica[polozenie_x + i, polozenie_y + j].usun(w, BackColor);
                rysujklocek(polozenie_x, polozenie_y, nowy);
    }

  }