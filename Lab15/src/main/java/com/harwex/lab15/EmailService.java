package com.harwex.lab15;

import jakarta.servlet.ServletContext;
import lombok.SneakyThrows;

import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import java.util.*;
import java.util.stream.Collectors;

public class EmailService {
    private static Folder folder;
    private static Properties smtpProps;
    private static Authenticator smtpAuth;

    @SneakyThrows
    public static void initSmtp(ServletContext context)
    {
        final String userEmail = context.getInitParameter("EmailName");
        final String userPassword = context.getInitParameter("EmailPassword");
        final String host = context.getInitParameter("smtp-host");
        final String port = context.getInitParameter("smtp-port");
        final String isAuth = context.getInitParameter("smtp-isAuth");
        final String sslTrust = context.getInitParameter("smtp-sslTrust");
        final String starttlsEnable = context.getInitParameter("smtp-starttlsEnable");

        Properties props = new Properties();
        props.put("mail.smtp.host", host);
        props.put("mail.smtp.port", port);
        props.put("mail.smtp.auth", isAuth);
        props.put("mail.smtp.ssl.trust", sslTrust);
        props.put("mail.smtp.starttls.enable", starttlsEnable);
        EmailService.smtpProps = props;

        EmailService.smtpAuth = new Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(userEmail, userPassword);
            }
        };
    }

    @SneakyThrows
    public static void initImap(ServletContext context)
    {
        final String userEmail = context.getInitParameter("EmailName");
        final String userPassword = context.getInitParameter("EmailPassword");
        final String host = context.getInitParameter("imap-host");
        final String sslTrust = context.getInitParameter("imap-sslTrust");

        var properties = new Properties();
        properties.put("mail.imaps.ssl.trust", sslTrust);

        var store = Session.getInstance(properties, new Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(userEmail, userPassword);
            }
        }).getStore("imaps");
        store.connect(host, userEmail, userPassword);

        Folder folder = store.getFolder("INBOX");
        folder.open(Folder.READ_ONLY);

        EmailService.folder = folder;
    }

    @SneakyThrows
    public static void sendEmail(final String from, final String to, final String message)
    {
        MimeMessage msg = new MimeMessage(Session.getInstance(smtpProps, smtpAuth));

        msg.addHeader("Content-type", "text/HTML; charset=UTF-8");
        msg.addHeader("format", "flowed");
        msg.addHeader("Content-Transfer-Encoding", "8bit");

        msg.setFrom(new InternetAddress(from, "Harwex"));
        msg.setSubject("Java lab16", "UTF-8");
        msg.setText(message, "UTF-8");
        msg.setSentDate(new Date());
        msg.setRecipients(Message.RecipientType.TO, InternetAddress.parse(to, false));
        Transport.send(msg);
    }

    @SneakyThrows
    public static String getMessagesMetaInfo()
    {
        StringBuilder result = new StringBuilder();
        var messages = Arrays.stream(folder.getMessages()).skip(folder.getMessageCount() - 10).collect(Collectors.toList());
        Collections.reverse(messages);
        for (var message : messages) {
            result.append("<div>");
            result.append("<p>Sender: ").append(InternetAddress.toString(message.getFrom())).append("<br/>");
            result.append("Subject: ").append(message.getSubject()).append("<br/>");
            result.append("Date: ").append(message.getSentDate()).append("</p>");
            var href = "/Lab15_war_exploded/concrete-message.jsp?id=" + message.getMessageNumber();
            result.append("<a href='").append(href).append("'>View message</a>");
            result.append("</div>");
        }
        return result.toString();
    }

    @SneakyThrows
    public static String getConcreteMessage(int id)
    {
        var message = folder.getMessage(id);
        String messageContent = "";
        String contentType = message.getContentType().toLowerCase();

        if (contentType.contains("multipart")) {
            Multipart multiPart = (Multipart) message.getContent();
            int numberOfParts = multiPart.getCount();
            for (int partCount = 0; partCount < numberOfParts; partCount++) {
                MimeBodyPart part = (MimeBodyPart) multiPart.getBodyPart(partCount);
                messageContent = part.getContent().toString();
            }
        }
        else if (contentType.contains("text/plain") || contentType.contains("text/html")) {
            Object content = message.getContent();
            if (content != null) {
                messageContent = content.toString();
            }
        }

        return messageContent;
    }
}
