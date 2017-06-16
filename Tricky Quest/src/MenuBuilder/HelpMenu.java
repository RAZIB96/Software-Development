/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package MenuBuilder;
import ImageLoader.LoadImage;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;

/**
 *
 * @author USER
 */
public class HelpMenu extends JFrame{
    
    JFrame Hmenu;
    
    void Set_Style(JFrame h_window)
    {
        h_window.setBounds(0,0,800,600);
        h_window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        h_window.setVisible(true);
        h_window.setLayout(null);
    }
    
    void Set_Style(JButton b,JLabel l)
    {
        l.setBounds(0,0,800,600);
        b.setBounds(600,500,170,50);
    }
    
    void Add_component(JButton b,JLabel l)
    {
        Hmenu.add(b);
        Hmenu.add(l);
    }
    
    void Display(final JFrame menuwindow)
    {
        Hmenu=new JFrame("Tricky Quest");  
        
        menuwindow.setVisible(false);
        
        JLabel Help=new JLabel(new ImageIcon(LoadImage.class.getResource("HelpMenu.jpg")));      
        JButton Back=new JButton(new ImageIcon(LoadImage.class.getResource("Back.jpg")));        
        
        Set_Style(Hmenu);
        Set_Style(Back, Help);
        Add_component(Back, Help);
        
        Back.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                Hmenu.dispose();
                menuwindow.setVisible(true);
            }
        });
        
    }
}
