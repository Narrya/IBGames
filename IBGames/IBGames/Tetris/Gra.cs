using System.Windows.Forms;
using System.Drawing;

public class graj : Panel
{
    protected Graphics w;
    protected element[,] tablica;
    protected int szerokosc;
    protected int wysokosc;

    public graj()
    {
        szerokosc = 10;
        wysokosc = 10;
        this.Size = new System.Drawing.Size(szerokosc * element.rozmiar + 4, wysokosc * element.rozmiar + 4);
        tablica = new element[szerokosc, wysokosc];
        for (int i = 0; i < szerokosc; i++)
            for (int j = 0; j < wysokosc; j++)
                tablica[i, j] = new element(i, j);
        w = CreateGraphics();
        this.Show();
    }

    public graj(int a, int b)
    {
        if (a <= 0 || b <= 0) a = b = 10;
        szerokosc = a;
        wysokosc = b;
        this.Size = new System.Drawing.Size(szerokosc * element.rozmiar + 4, wysokosc * element.rozmiar + 4);
        tablica = new element[szerokosc, wysokosc];
        for (int i = 0; i < szerokosc; i++)
            for (int j = 0; j < wysokosc; j++)
                tablica[i, j] = new element(i, j);
        w = CreateGraphics();
        this.Show();
    }

    public bool sprawdz(int x, int y)
    {
        if (x < 0 || x >= szerokosc || y < 0 || y >= wysokosc) 
            return false;
        else return true;
    }

    public bool rysuj(int x, int y)
    {
        if (!sprawdz(x, y)) 
            return false;
        if (tablica[x, y].spr()) 
            return false;
        tablica[x, y].wyswietl(w);
        return true;
    }

    public void refresh()
    {
        for (int i = 0; i < szerokosc; i++)
            for (int j = 0; j < wysokosc; j++)
            {
                if (tablica[i, j].spr())
                    tablica[i, j].wyswietl(w);
            }
    }

    public void reset()
    {
        for (int i = 0; i < szerokosc; i++)
            for (int j = 0; j < wysokosc; j++)
                tablica[i, j].usun(w, BackColor);
    }
}