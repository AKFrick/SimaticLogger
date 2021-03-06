﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaticLogger
{
    /// <summary>
    /// message, received from PLC. Contains <see cref="Text"/> and <see cref="Date"/>
    /// </summary>
    public class Message
    {
        /// <summary>
        /// text of message. Creating in PLC
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Date of message created
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// New message
        /// </summary>
        /// <param name="text">text of message. Creating in PLC</param>
        /// <param name="date">not using yet</param>
        public Message(string text, string date)
        {
            Text = text;
            Date = date;
        }
        /// <summary>
        /// New Message
        /// </summary>
        /// <param name="text">text of message</param>
        public Message(string text)
        {
            Text = text;
        }
    }
}
