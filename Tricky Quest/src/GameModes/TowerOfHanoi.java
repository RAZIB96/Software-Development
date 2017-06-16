/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package GameModes;

import ImageLoader.LoadImage;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 *
 * @author user1
 */
public class TowerOfHanoi extends JPanel implements Runnable,MouseListener,MouseMotionListener{
    
    JFrame Level1,Level2,LW;
    int Towers[][]=new int[4][4];
    int Disk[]=new int[4];
    int mx,my,move_x,move_y,picked,score;
    ImageIcon img;
    Thread t;
    Boolean GameOver,NextStageCheck;
    String action;
    
    public TowerOfHanoi(JFrame L1,JFrame L2,JFrame LevelWindow,int s){
        Level1=L1;  Level2=L2;  LW=LevelWindow;
        
        Towers[1][1]=3; Towers[1][2]=2; Towers[1][3]=1;
        
        Disk[1]=3; Disk[2]=0; Disk[3]=0;
        
        GameOver=NextStageCheck=false;
        
        action="Pick";
        picked=-1;
        score=s+300;
        
        Level2.addMouseListener(this);
        Level2.addMouseMotionListener(this);
        
        start();
    }
    
    void start(){
        t=new Thread(this);
        t.start();
    }
    
    @Override
    public void run() {
        while(!GameOver){
            try {
                t.sleep(0);
                repaint();
                NextStageCheck=NextLevelCheck();
                GameOver=GameoverCheck();
            } catch (InterruptedException ex) {
            }
        }
        
        if (GameOver && NextStageCheck) {
            Level2.setVisible(false);
            MagicSquareFrame MSF=new MagicSquareFrame(Level1,Level2,LW,score);
            MSF.Display();
        } else if (GameOver && !NextStageCheck) {
            LW.setVisible(true);
            Level1.dispose();
            Level2.dispose();
        }
    }
    
    boolean NextLevelCheck() {
        if (Towers[2][1]==3 && Towers[2][2]==2 && Towers[2][3]==1) return true;
        if (Towers[3][1]==3 && Towers[3][2]==2 && Towers[3][3]==1) return true;

        return false;
    }
    
    boolean ExitCheck() {
        int b;
        b = BoxCheck(mx, my);

        if (b == 7) {
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
    
    int BoxCheck(int x, int y) {
        
        if (x >= 145 && x <= 265 && y >= 150 && y <= 320) {
            return 0;
        } else if (x >= 345 && x <= 465 && y >= 150 && y <= 320) {
            return 1;
        } else if (x >= 545 && x <= 665 && y >= 150 && y <= 320) {
            return 2;
        } else if (x >= 160 && x <= 260 && y >= 350 && y <= 380) {
            return 3;
        } else if (x >= 360 && x <= 460 && y >= 350 && y <= 380) {
            return 4;
        } else if (x >= 560 && x <= 660 && y >= 350 && y <= 380) {
            return 5;
        } else if (x >= 300 && x <= 500 && y >= 450 && y <= 480) {
            return 6;
        } else if (x >= 300 && x <= 500 && y >= 500 && y <= 530) {
            return 7;
        }

        return -1;
    }
    
    void Valid_Color(Graphics g,int box_no){
        if (picked==-1) g.setColor(Color.yellow);
        else{
            if (Disk[box_no]==0)                                                g.setColor(Color.blue);
            else if (Towers[box_no][Disk[box_no]]>Towers[picked][Disk[picked]]) g.setColor(Color.blue);
            else                                                                g.setColor(Color.red);
        }
    }
    
    void Temporary_Mark(Graphics g) {
        int box_no = BoxCheck(move_x, move_y);

        g.setColor(Color.GRAY);
        if (box_no >= 0 && box_no <= 2) {
            Valid_Color(g,box_no+1);
            g.drawRect(145+box_no*200, 145, 130, 185);
        } else if (box_no >= 3 && box_no <= 5) {
            g.fill3DRect(160+(box_no%3)*200, 350, 100, 30, true);
        } else if (box_no >= 6 && box_no <= 7){
            g.fill3DRect(300, 450 + (50 * (box_no % 6)), 200, 30, true);
        }
    }
    
    void Permanent_Mark(Graphics g){
        g.setColor(Color.green);
        g.drawRect(145+(picked-1)*200, 145, 130, 185);
    }
    
    void Pick_Drop_Check(){
        int b=BoxCheck(mx, my);
        
        if (b>=3 && b<=5){
            b=b%3+1;
            if (picked==-1){
                if (Disk[b]!=0){
                    picked=b;
                    action="Drop";
                }
            }
            else{
                if (Disk[b]==0 || Towers[b][Disk[b]]>=Towers[picked][Disk[picked]]){
                    int temp=Towers[picked][Disk[picked]];
                    Disk[picked]--;
                    Towers[b][++Disk[b]]=temp;
                    picked=-1;
                    action="Pick";
                    if (score>0) score-=10;
                }
            }
            b=mx=my=-1;
        }
    }
    
    void ScoreShow(Graphics g) {
        g.setColor(Color.BLUE);
        g.setFont(new Font("Impact", Font.BOLD, 25));
        g.drawString("Score: ", 330, 50);

        String stringscore = String.valueOf(score);
        g.drawString(stringscore, 430, 50);
    }
    
    void Reset_Check() {
        int b;
        b = BoxCheck(mx, my);

        if (b == 6) {
            Towers[1][1]=3; Towers[1][2]=2; Towers[1][3]=1;
        
            Disk[1]=3; Disk[2]=0; Disk[3]=0;
            
            b = -1;
            
            score=300;
        }
    }
    
    void Pick_Drop_Buttons(Graphics g){
        g.setColor(Color.lightGray);
        g.fill3DRect(160, 350, 100, 30, true);
        g.fill3DRect(360, 350, 100, 30, true);
        g.fill3DRect(560, 350, 100, 30, true);
    }
    
    void Button_Label(Graphics g){
        g.setColor(Color.black);
        g.setFont(new Font("Impact", Font.BOLD, 20));
        for (int i=0; i<3; i++){
            g.drawString(action, 190+i*200, 370);
        }
        
        g.drawString("Restart", 365, 470);
        g.drawString("Exit", 375, 520);
    }
    
    @Override
    public void paint(Graphics g){
        g.setColor(Color.black);
        g.fillRect(0,0,800,600);
        
        img=new ImageIcon(LoadImage.class.getResource("Pole.jpg"));
        for (int i=0; i<3; i++){
            img.paintIcon(this, g, 200+i*200, 150);
        }
        
        g.setColor(Color.lightGray);
        g.fill3DRect(300, 450, 200, 30, true);
        g.fill3DRect(300, 500, 200, 30, true);
        
        ScoreShow(g);
        Pick_Drop_Buttons(g);
        if (!GameOver){
            Temporary_Mark(g);
            Permanent_Mark(g);
            Reset_Check();
            Pick_Drop_Check();
        }
        Button_Label(g);
        
        for (int i=1; i<=3; i++){
            for (int j=1; j<=Disk[i]; j++){
                String temp="Disk"+String.valueOf(Towers[i][j])+".jpg";
                img=new ImageIcon(LoadImage.class.getResource(temp));
                
                if (Towers[i][j]==3)        img.paintIcon(this, g, 150+(i-1)*200, 300-(j-1)*30);
                else if (Towers[i][j]==2)   img.paintIcon(this, g, 160+(i-1)*200, 300-(j-1)*30);
                else if (Towers[i][j]==1)   img.paintIcon(this, g, 170+(i-1)*200, 300-(j-1)*30);
            }
        }
    }
    
    @Override
    protected void paintComponent(Graphics g){
        super.paintComponent(g);
    }
    
    @Override
    public void mouseClicked(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mousePressed(MouseEvent me) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        mx=me.getX()-8;
        my=me.getY()-30;
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
        move_x=me.getX()-8;
        move_y=me.getY()-30;
    }
}
