/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package GameModes;

import ImageLoader.LoadImage;
import java.awt.Font;
import java.awt.HeadlessException;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComponent;
import javax.swing.JFrame;
import static javax.swing.JFrame.EXIT_ON_CLOSE;
import javax.swing.JLabel;

/**
 *
 * @author user1
 */
public class TowerOfHanoiFrame extends JFrame{
    JFrame Level1,LW,Level2;
    JFrame Hpopmenu;
    int score;

    public TowerOfHanoiFrame(JFrame L,JFrame LevelWindow,int s){
        Level1=L;
        LW=LevelWindow;
        score=s;
    }
    
    void Set_Style(JFrame Level2){
        Level2.setBounds(0,0,800,600);
        Level2.setDefaultCloseOperation(EXIT_ON_CLOSE);
        Level2.setVisible(true);
        Level2.setLayout(null);
    }
    
    public void Display(){
        Level2=new JFrame("Tricky Quest");
        Set_Style(Level2);
        
        TowerOfHanoi TH=new TowerOfHanoi(Level1,Level2,LW,score);
        JComponent newContentPane=TH;
        newContentPane.setOpaque(true);
        
        Level2.setContentPane(newContentPane);
        
        Hpopmenu =new JFrame("Hint for Tower of Hanoi");
        JLabel hint=new JLabel(new ImageIcon(LoadImage.class.getResource("Hanoi.jpg")));
        JButton resume=new JButton("Continue");
        
        Hpopmenu.setBounds(50, 50, 700 , 500);
        Hpopmenu.setVisible(true);
        Hpopmenu.setDefaultCloseOperation(EXIT_ON_CLOSE);
        Hpopmenu.setLayout(null);        
        
        hint.setBounds(0, 0, 700, 500);
        
        resume.setFont(new Font("Consolas",Font.BOLD,14));        
        resume.setBounds(500, 410, 100, 50);
        
        Hpopmenu.add(hint);
        Hpopmenu.add(resume);     
        
        resume.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                Hpopmenu.dispose();
            }            
        });
    }   
}
