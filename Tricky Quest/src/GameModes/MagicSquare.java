/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package GameModes;

import ImageLoader.LoadImage;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 *
 * @author user1
 */
public class MagicSquare extends JPanel implements Runnable,MouseListener,MouseMotionListener{
    private int MagicSquare[][]=new int[3][3],score;
    private int mx,my,b,box1=-1,box2=-1,move_x,move_y,canvas_height,canvas_width;
    private boolean exchange,clicked,Gameover,Nextstage;
    private ImageIcon background=new ImageIcon(LoadImage.class.getResource("MagicSquareBack.jpg"));
    private ImageIcon img;
    private Thread t;
    private JFrame Level1,Level2,Level3,LW;
    
    public MagicSquare(){
        
    }
    
    public MagicSquare(JFrame L1,JFrame L2,JFrame L3,JFrame LevelWindow,int s){
        this.setBounds(0, 0, 800, 600);
        Level1=L1;
        Level2=L2;
        Level3=L3;
        LW=LevelWindow;
        
        score=s+500;

        Level3.addMouseListener(this);
        Level3.addMouseMotionListener(this);
        
        for (int i=0; i<3; i++)
            for (int j=0; j<3; j++)
                MagicSquare[i][j]=i*3+j+1;
        
        Gameover=Nextstage=false;
        start();
    }
    
    public void start(){
        t=new Thread(this);
        t.start();
    }
    
    boolean NextStageCheck(){
        if (MagicSquare[0][0]+MagicSquare[0][1]+MagicSquare[0][2]!=15) return false;
        if (MagicSquare[1][0]+MagicSquare[1][1]+MagicSquare[1][2]!=15) return false;
        if (MagicSquare[2][0]+MagicSquare[2][1]+MagicSquare[2][2]!=15) return false;
        if (MagicSquare[0][0]+MagicSquare[1][0]+MagicSquare[2][0]!=15) return false;
        if (MagicSquare[0][1]+MagicSquare[1][1]+MagicSquare[2][1]!=15) return false;
        if (MagicSquare[0][2]+MagicSquare[1][2]+MagicSquare[2][2]!=15) return false;
        if (MagicSquare[0][0]+MagicSquare[1][1]+MagicSquare[2][2]!=15) return false;
        if (MagicSquare[2][0]+MagicSquare[1][1]+MagicSquare[0][2]!=15) return false;
        
        return true;
    }
    
    boolean Exit_Check(){
        b=BoxCheck(mx, my);
        
        return (b==10);
    }
    
    boolean GameOverCheck(){
        if (NextStageCheck()) return true;
        if (Exit_Check())     return true;
        
        return false;
    }
    
    @Override
    public void run() {
        while(!Gameover){
            try {
                t.sleep(0);
                repaint();
                Nextstage=NextStageCheck();
                Gameover=GameOverCheck();
            } catch (InterruptedException ex){}
        }
        
        if (Nextstage && Gameover){
            
        }
        else if (!Nextstage && Gameover){
            LW.setVisible(true);
            Level1.dispose();
            Level2.dispose();
            Level3.dispose();
        }
    }
    
    int BoxCheck(int x,int y){
        if (x>=260 && x<=340 && y>=110 && y<=190) return 0;
        else if (x>=360 && x<=440 && y>=110 && y<=190) return 1;
        else if (x>=460 && x<=540 && y>=110 && y<=190) return 2;
        else if (x>=260 && x<=340 && y>=210 && y<=290) return 3;
        else if (x>=360 && x<=440 && y>=210 && y<=290) return 4;
        else if (x>=460 && x<=540 && y>=210 && y<=290) return 5;
        else if (x>=260 && x<=340 && y>=310 && y<=390) return 6;
        else if (x>=360 && x<=440 && y>=310 && y<=390) return 7;
        else if (x>=460 && x<=540 && y>=310 && y<=390) return 8;
        else if (x>=300 && x<=500 && y>=450 && y<=480) return 9;
        else if (x>=300 && x<=500 && y>=500 && y<=530) return 10;
        
        return -1;
    }
    
    void CheckClick(){
        if (clicked){
            clicked=false;
            b=BoxCheck(mx,my);
            
            if (b>=0 && b<=8){
                if (!exchange){
                    exchange=true;
                    box1=b;
                }
                else{
                    box2=b;
                    int temp=MagicSquare[box1/3][box1%3];                       //swapping values
                    MagicSquare[box1/3][box1%3]=MagicSquare[box2/3][box2%3];
                    MagicSquare[box2/3][box2%3]=temp;
                    exchange=false;
                    
                    if (score>200 && box1!=box2) score-=10;
                    
                    box1=box2=-1;
                }
            }
        }
    }
    
    void Temporary_Mark(Graphics g){
        int box_no=BoxCheck(move_x,move_y);
        
        g.setColor(Color.GRAY);
        if (box_no>=0 && box_no<=8)
            g.fill3DRect(250+(box_no%3)*100, 100+(box_no/3)*100, 100, 100, true);
        else if (box_no>=9 && box_no<=10)
            g.fill3DRect(300, 450+(50*(box_no%9)), 200, 30, true);
    }
    
    void Permanent_Mark(Graphics g){
        g.setColor(Color.DARK_GRAY);
        if (box1>=0 && box1<=8)
            g.fill3DRect(250+(box1%3)*100, 100+(box1/3)*100, 100, 100, true);
    }
    
    void ScoreShow(Graphics g){
        g.setColor(Color.BLUE);
        g.setFont(new Font("Impact",Font.BOLD, 25));
        g.drawString("Score: ", 330, 50);
        
        String stringscore=String.valueOf(score);
        g.drawString(stringscore, 430, 50);
    }
    
    void Reset_Check(){
        b=BoxCheck(mx, my);
        
        if (b==9){
            for (int i=0; i<3; i++)
                for (int j=0; j<3; j++)
                    MagicSquare[i][j]=i*3+j+1;
            score=500;
            b=-1;
        }
    }
    
    @Override
    public void paint(Graphics g){
        background.paintIcon(this, g, 0, 0);
        
        g.setColor(Color.LIGHT_GRAY);
        g.fill3DRect(250,100,300,300,true);
        g.fill3DRect(300,450,200,30,true);
        g.fill3DRect(300,500,200,30,true);
        
        CheckClick();
        ScoreShow(g);
        
        if (!Gameover){
            Temporary_Mark(g);
            Permanent_Mark(g);
            Reset_Check();
        }
        
        g.setColor(Color.BLACK);
        g.setFont(new Font("Impact",Font.BOLD,20));
        g.drawString("Restart",365,470);
        g.drawString("Exit",375,520);
        
        for (int i=0; i<3; i++)
            for (int j=0; j<3; j++){
                String temp=String.valueOf(MagicSquare[i][j])+".jpg";
                img=new ImageIcon(LoadImage.class.getResource(temp));
                img.paintIcon(this, g,260+j*100,110+i*100);
            }
    }
    
    @Override
    public void mousePressed(MouseEvent me) {
        mx=me.getX()-8;
        my=me.getY()-30;
        clicked=true;
    }
    
    @Override
    public void mouseMoved(MouseEvent me) {
        move_x=me.getX()-8;
        move_y=me.getY()-30;
    }
    
    @Override
    protected void paintComponent(Graphics g){
        super.paintComponent(g);
    }
    
    @Override
    public void mouseClicked(MouseEvent me) {
        
    }

    @Override
    public void mouseReleased(MouseEvent me) {
        
    }

    @Override
    public void mouseEntered(MouseEvent me) {
        
    }

    @Override
    public void mouseExited(MouseEvent me) {
        
    }

    @Override
    public void mouseDragged(MouseEvent me) {
        
    }
}
