/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package MenuBuilder;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;

/**
 *
 * @author user1
 */
public class PopUpWindow extends JFrame{
    JFrame windowPop;
    
    void Set_Style(JFrame window){
        window.setBounds(250, 200, 300 , 200);
        window.setVisible(true);
        window.setDefaultCloseOperation(EXIT_ON_CLOSE);
        window.setLayout(null);
    }
    
    void Set_Style(JLabel label){
        label.setFont(new Font("consolas",Font.ITALIC,15));
        label.setBounds(45, 40, 250, 40);
    }
    
    void Set_Style(JButton b1,JButton b2){
        b1.setFont(new Font("Consolas",Font.BOLD,14));
        b2.setFont(new Font("Consolas",Font.BOLD,14));
        b1.setBounds(50, 120, 60, 30);
        b2.setBounds(170, 120, 60, 30);
    }
    
    void Add_Component(JButton b1,JButton b2,JLabel label){
        windowPop.add(b1);
        windowPop.add(b2);
        windowPop.add(label);
    }
    
    void Display(){
        windowPop=new JFrame("Confirmation");
        JLabel message=new JLabel("Do you really want to quit?");
        JButton yes=new JButton("Yes");
        JButton no=new JButton("No");
        
        Set_Style(windowPop);
        Set_Style(message);
        Set_Style(yes,no);
        Add_Component(yes, no, message);
        
        yes.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                System.exit(0);
            }
        });
        no.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
                windowPop.dispose();
            }
        });
    }
}
