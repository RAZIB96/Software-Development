/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package MenuBuilder;
import ImageLoader.LoadImage;
import GameModes.MagicSquareFrame;
import GameModes.PuzzleManiaFrame;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
/**
 *
 * @author user1
 */
public class GameLevelChoice extends JFrame{
    JFrame LevelWindow;
    PuzzleManiaFrame PMF;
    
    
    void Set_Style(JFrame L_Window){
        L_Window.setBounds(0,0,800,600);
        L_Window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        L_Window.setVisible(true);
        L_Window.setLayout(null);
    }
    
    void Set_Style(JButton b1,JButton b2,JButton b3,JLabel lab1){
        b1.setBounds(325,20,170,50);
        b2.setBounds(325,500,170,50);
        b3.setBounds(20,20,170,50);
        lab1.setBounds(0, 0, 800, 600);
    }
    
    void Add_Component(JButton b1,JButton b2,JButton b3,JLabel lab1){
        LevelWindow.add(b1);
        LevelWindow.add(b2);
        LevelWindow.add(b3);
        LevelWindow.add(lab1);
    }
    
    public void Display(final JFrame menuWindow){
        LevelWindow=new JFrame("Tricky Quest");
        
        JLabel GameMenu=new JLabel( new ImageIcon(LoadImage.class.getResource("GameMenu.jpg")));
        JButton Story = new JButton( new ImageIcon(LoadImage.class.getResource("Campaign.jpg")));
        JButton Arcade = new JButton( new ImageIcon(LoadImage.class.getResource("Manual.jpg")));
        JButton Back = new JButton( new ImageIcon(LoadImage.class.getResource("Back.jpg")));
        
        menuWindow.setVisible(false);
        
        Set_Style(LevelWindow);
        Set_Style(Story,Arcade,Back,GameMenu);
        Add_Component(Story, Arcade, Back,GameMenu);
        
        Story.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                PMF=new PuzzleManiaFrame(LevelWindow);
                PMF.Display();
            }
        });
        
        Back.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                LevelWindow.dispose();
                menuWindow.setVisible(true);
            }
        });
    }
}
