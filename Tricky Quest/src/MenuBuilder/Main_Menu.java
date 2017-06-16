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
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;


/**
 *
 * @author user1
 */
public class Main_Menu extends JFrame{
    PopUpWindow popWin; //pop up window for exit button
    GameLevelChoice Game;   //Game level choice menu
    HighScoreDisplay Score;
    HelpMenu H_menu;
    JFrame menuWindow;
    
    void Set_Style(JFrame M_Window){
        M_Window.setBounds(0,0,800,600);
        M_Window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        M_Window.setVisible(true);
        M_Window.setLayout(null);
    }
    
    void Set_Style(JButton b1,JButton b2,JButton b3,JButton b4,JLabel lab1){
        b1.setBounds(610, 10, 170, 50);
        b2.setBounds(5, 10, 170, 50);
        b3.setBounds(610, 505, 170, 50);
        b4.setBounds(5, 505, 170, 50);
        lab1.setBounds(0,0,800,600);
    }
    
    void Add_Component(JButton b1,JButton b2,JButton b3,JButton b4,JLabel lab1){
        menuWindow.add(b1);
        menuWindow.add(b2);
        menuWindow.add(b3);
        menuWindow.add(b4);
        menuWindow.add(lab1);
    }
    
    public void Display(){
        menuWindow=new JFrame("Tricky Quest");
        
        JLabel BackGround=new JLabel( new ImageIcon(LoadImage.class.getResource("MenuBack.jpg")));
        
        JButton playGame = new JButton( new ImageIcon(LoadImage.class.getResource("NewGame.jpg")));
        JButton help = new JButton( new ImageIcon(LoadImage.class.getResource("Help.jpg")));
        JButton statistic = new JButton( new ImageIcon(LoadImage.class.getResource("HighScore.jpg")));
        JButton endGame = new JButton( new ImageIcon(LoadImage.class.getResource("Exit.jpg")));
        
        Set_Style(menuWindow);
        Set_Style(playGame, help, statistic, endGame, BackGround);
        Add_Component(playGame, help, statistic, endGame, BackGround);
        
        playGame.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                Game= new GameLevelChoice();
                Game.Display(menuWindow);
            }
        });
        
        //actions that will happen for "help" button
        help.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                
                H_menu=new HelpMenu();
                H_menu.Display(menuWindow);
            }
        });
        
        //actions that will happen for "Highscores" button
        statistic.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                Score=new HighScoreDisplay();
                Score.Display(menuWindow);
            }
        });
        
        //actions that will happen for "Exit" button
        endGame.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                popWin=new PopUpWindow();
                popWin.Display();
            }
        });
    }
}
