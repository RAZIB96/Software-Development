/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package MenuBuilder;
import ImageLoader.LoadImage;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.ImageIcon;

/**
 *
 * @author user1
 */
public class HighScoreDisplay extends JFrame{
    JFrame High;
    
    void SetStyle(JFrame ScoreWindow){
        ScoreWindow.setBounds(0,0,800,600);
        ScoreWindow.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        ScoreWindow.setVisible(true);
        ScoreWindow.setLayout(null);
    }
    
    void SetStyle(JButton b1,JButton b2){
        b1.setBounds(20,20,170,50);
        b2.setBounds(20,480,170,50);
    }
    
    void AddComponent(JButton b1,JButton b2){
        High.add(b1);
        High.add(b2);
    }
    
    public void Display(final JFrame menuwindow){
        High=new JFrame("Tricky Quest");
        menuwindow.setVisible(false);
        JButton Back=new JButton( new ImageIcon(LoadImage.class.getResource("Back.jpg")));
        JButton Reset=new JButton( new ImageIcon(LoadImage.class.getResource("Reset.jpg")));
        
        SetStyle(High);
        SetStyle(Back,Reset);
        AddComponent(Back,Reset);
        
        Back.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent ae) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                menuwindow.setVisible(true);
                High.dispose();
            }
        });
        Reset.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent ae) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
            }
        });
    }
}
