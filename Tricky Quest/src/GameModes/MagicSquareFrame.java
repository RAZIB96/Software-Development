/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package GameModes;

import ImageLoader.LoadImage;
import java.awt.Font;
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
public class MagicSquareFrame extends JFrame{
    JFrame Level1,Level2,Level3,LW;
    JFrame Hpopmenu;
    int score;

    public MagicSquareFrame(JFrame L1,JFrame L2,JFrame LevelWindow,int s){
        Level1=L1;
        Level2=L2;
        score=s;
        LW=LevelWindow;
    }
    
    void Set_Style(JFrame Level3){
        Level3.setBounds(0,0,800,600);
        Level3.setDefaultCloseOperation(EXIT_ON_CLOSE);
        Level3.setVisible(true);
        Level3.setLayout(null);
    }
    
    public void Display(){
        Level3=new JFrame("Tricky Quest");
        Set_Style(Level3);
        
        MagicSquare MS=new MagicSquare(Level1,Level2,Level3,LW,score);
        JComponent newContentPane=MS;
        newContentPane.setOpaque(true);
        
        Level3.setContentPane(newContentPane);        
        
        Hpopmenu =new JFrame("Hint for Magic Square");
        JLabel hint=new JLabel(new ImageIcon(LoadImage.class.getResource("MagicSquareHint.jpg")));
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
