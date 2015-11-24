package sample;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import javafx.application.Application;
import javafx.geometry.Rectangle2D;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.HBox;
import javafx.scene.paint.Color;
import javafx.stage.Stage;

public class Main extends Application {

    @FXML
    private Button submitBtn;
    private TextArea InputBox;
    private ImageView ImageBox;
    @Override
    public void start(Stage primaryStage) throws Exception{

        // PHYSICAL ANGER
        Parent root = FXMLLoader.load(getClass().getResource("testform.fxml"));

        primaryStage.setTitle("Image viewer");
        primaryStage.setResizable(false);
        Scene mainScene = new Scene(root);
        primaryStage.setScene(mainScene);


        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
