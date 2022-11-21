package com.harwex.lab16;

import jakarta.websocket.*;
import jakarta.websocket.server.ServerEndpoint;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

@ServerEndpoint("/websocket")
public class WebSocketHandler {
    @OnOpen
    public void onOpen(Session session)
    {
        try
        {
            while (session.isOpen())
            {
                String message = new SimpleDateFormat("HH:mm:ss").format(new Date());
                if (session.isOpen()) {
                    session.getBasicRemote().sendText(message);
                }
                Thread.sleep(2000);
            }
        }
        catch (Exception e)
        {
            System.out.println(e.getMessage());
        }
    }
}