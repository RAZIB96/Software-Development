/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GameModes;

import java.awt.Graphics;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import ImageLoader.LoadImage;
import java.awt.Color;
import java.awt.Font;

/**
 *
 * @author user1
 */
public class PuzzleMania extends JPanel implements Runnable, MouseListener, MouseMotionListener {

    JFrame Level1, LW;
    int Puzzle[][] = new int[2][2];
    ImageIcon img;
    int mx, my, move_x, move_y, score;
    Thread t;
    boolean Gameover, NextLevel;

    PuzzleMania() {

    }

    PuzzleMania(JFrame L, JFrame LevelWindow) {
        Level1 = L;
        LW = LevelWindow;
        Gameover = false;
        NextLevel = false;
        score = 100;

        Puzzle[0][0] = 2;
        Puzzle[0][1] = 3;
        Puzzle[1][0] = 0;
        Puzzle[1][1] = 1;

        Level1.addMouseListener(this);
        Level1.addMouseMotionListener(this);
        start();
    }

    public void start() {
        t = new Thread(this);
        t.start();
    }

    boolean NextLevelCheck() {
        if (Puzzle[0][0] == 1 && Puzzle[0][1] == 2 && Puzzle[1][1] == 3) {
            return true;
        }

        return false;
    }

    boolean ExitCheck() {
        int b;
        b = BoxCheck(mx, my);

        if (b == 5) {
            return true;
        }

        return false;
    }

    boolean GameoverCheck() {
        if (NextLevelCheck()) {
            return true;
        }
        if (ExitCheck()) {
            return true;
        }
        return false;
    }

    @Override
    public void run() {
        while (!Gameover) {
            try {
                t.sleep(0);
                repaint();
                Gameover = GameoverCheck();
                NextLevel = NextLevelCheck();

            } catch (InterruptedException ex) {
            }
        }

        if (Gameover && NextLevel) {
            Level1.setVisible(false);
            TowerOfHanoiFrame TOH=new TowerOfHanoiFrame(Level1,LW,score);
            TOH.Display();
        } else if (Gameover && !NextLevel) {
            LW.setVisible(true);
            Level1.dispose();
        }
    }

    int BoxCheck(int x, int y) {
        if (x >= 267 && x <= 395 && y >= 107 && y <= 235) {
            return 0;
        } else if (x >= 405 && x <= 533 && y >= 107 && y <= 235) {
            return 1;
        } else if (x >= 267 && x <= 395 && y >= 245 && y <= 373) {
            return 2;
        } else if (x >= 405 && x <= 533 && y >= 245 && y <= 373) {
            return 3;
        } else if (x >= 300 && x <= 500 && y >= 450 && y <= 480) {
            return 4;
        } else if (x >= 300 && x <= 500 && y >= 500 && y <= 530) {
            return 5;
        }

        return -1;
    }

    void Temporary_Mark(Graphics g) {
        int box_no = BoxCheck(move_x, move_y);

        g.setColor(Color.GRAY);
        if (box_no >= 0 && box_no <= 3) {
            g.fill3DRect(260 + (box_no % 2) * 140, 100 + (box_no / 2) * 140, 140, 140, true);
        } else if (box_no >= 4 && box_no <= 5) {
            g.fill3DRect(300, 450 + (50 * (box_no % 4)), 200, 30, true);
        }
    }

    boolean IsValid(int i, int j) {
        if (i < 0 || i >= 2) {
            return false;
        }
        if (j < 0 || j >= 2) {
            return false;
        }
        return true;

    }

    void SwapBox(int i, int j) {
        if (IsValid(i, j + 1) && Puzzle[i][j + 1] == 0) {

            int temp = Puzzle[i][j];
            Puzzle[i][j] = Puzzle[i][j + 1];
            Puzzle[i][j + 1] = temp;

            if (score > 0) {
                score -= 5;
            }

        } else if (IsValid(i, j - 1) && Puzzle[i][j - 1] == 0) {

            int temp = Puzzle[i][j];
            Puzzle[i][j] = Puzzle[i][j - 1];
            Puzzle[i][j - 1] = temp;

            if (score > 0) {
                score -= 5;
            }
        } else if (IsValid(i - 1, j) && Puzzle[i - 1][j] == 0) {

            int temp = Puzzle[i][j];
            Puzzle[i][j] = Puzzle[i - 1][j];
            Puzzle[i - 1][j] = temp;

            if (score > 0) {
                score -= 5;
            }
        } else if (IsValid(i + 1, j) && Puzzle[i + 1][j] == 0) {

            int temp = Puzzle[i][j];
            Puzzle[i][j] = Puzzle[i + 1][j];
            Puzzle[i + 1][j] = temp;

            if (score > 0) {
                score -= 5;
            }
        }
    }

    void ScoreShow(Graphics g) {
        g.setColor(Color.BLUE);
        g.setFont(new Font("Impact", Font.BOLD, 25));
        g.drawString("Score: ", 330, 50);

        String stringscore = String.valueOf(score);
        g.drawString(stringscore, 430, 50);
    }

    void CheckClick() {
        int b = BoxCheck(mx, my);

        if (b >= 0 && b <= 3) {

            int i = b / 2, j = b % 2;
            if (Puzzle[i][j] != 0) {
                SwapBox(i, j);
            }
        }

        b = -1;

    }

    void Reset_Check() {
        int b;
        b = BoxCheck(mx, my);

        if (b == 4) {
            Puzzle[0][0] = 2;
            Puzzle[0][1] = 3;
            Puzzle[1][0] = 0;
            Puzzle[1][1] = 1;
            score = 100;
            b = -1;
        }
    }

    @Override
    public void paint(Graphics g) {
        g.setColor(Color.black);
        g.fillRect(0, 0, 800, 600);

        g.setColor(Color.darkGray);
        g.fill3DRect(260, 100, 280, 280, true);

        g.setColor(Color.lightGray);
        g.fill3DRect(300, 450, 200, 30, true);
        g.fill3DRect(300, 500, 200, 30, true);

        ScoreShow(g);
        if (!Gameover){
            CheckClick();
            Temporary_Mark(g);
            Reset_Check();
        }

        g.setColor(Color.BLACK);
        g.setFont(new Font("Impact", Font.BOLD, 20));
        g.drawString("Restart", 365, 470);
        g.drawString("Exit", 375, 520);

        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                String Name = "Puzzle" + String.valueOf(Puzzle[i][j]) + ".jpg";
                img = new ImageIcon(LoadImage.class.getResource(Name));
                img.paintIcon(this, g, 267 + j * 138, 107 + i * 138);
            }
        }
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
    }

    @Override
    public void mouseClicked(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mousePressed(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        mx = me.getX() - 8;
        my = me.getY() - 30;
    }

    @Override
    public void mouseReleased(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mouseEntered(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mouseExited(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mouseDragged(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mouseMoved(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        move_x = me.getX() - 8;
        move_y = me.getY() - 30;
    }

}
