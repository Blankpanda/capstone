// ░░░░░░░░▄▄▄▀▀▀▄▄███▄░░░░░░░░░░░░░░░░░
// ░░░░░▄▀▀░░░░░░░▐░▀██▌░░░░░░░░░░░░░░░░
// ░░░▄▀░░░░▄▄███░▌▀▀░▀█░░░░░░░░░░░░░░░░
// ░░▄█░░▄▀▀▒▒▒▒▒▄▐░░░░█▌░░░░░░░░░░░░░░░
// ░▐█▀▄▀▄▄▄▄▀▀▀▀▌░░░░░▐█▄░░░░░░░░░░░░░░
// ░▌▄▄▀▀░░░░░░░░▌░░░░▄███████▄░░░░░░░░░
// ░░░░░░░░░░░░░▐░░░░▐███████████▄░░░░░░
// ░░░░░le░░░░░░░▐░░░░▐█████████████▄░░░
// ░░░░toucan░░░░░░▀▄░░░▐██████████████▄ ░░
// ░░░░has░░░░░░░░▀▄▄████████████████▄ ░░░
// ░░arrived░░░░░░░░░░░░█▀██████░░░░░
package sample;

import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;

import javax.swing.*;
import javax.swing.plaf.basic.BasicInternalFrameTitlePane;
import java.awt.event.ActionEvent;
import java.net.URL;
import java.util.ResourceBundle;

public class sampleController {

    @FXML
    private Button submitBtn;
    private TextArea inputBox;
    private ImageView imageBox;


    public void initialize(URL url, ResourceBundle bundle){
        submitBtn.setOnAction(new EventHandler<javafx.event.ActionEvent>() {
            @Override
            public void handle(javafx.event.ActionEvent event) {
                System.out.println("asdfghjkl;");
            }
        });
    }
}
