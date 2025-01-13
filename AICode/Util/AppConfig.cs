using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace AICode
{
    /*应用程序配置类*/
    class AppConfig
    {
        private string configFilePath = null;
        private int x, y;
        private int opacity;
        bool topMost;
        public AppConfig()
        {
            x = Screen.PrimaryScreen.WorkingArea.Width - 110; //logo的默认x坐标
            y = Screen.PrimaryScreen.WorkingArea.Height - 60; //logo的默认y坐标
            opacity = 100;
            topMost = true;
            configFilePath =  Application.StartupPath + "\\config.xml"; //配置文件路径
        }

        public void loadConfigFile() {
            try
            {
                FileInfo file = new FileInfo(configFilePath);
                if(file.Exists)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(configFilePath);
                    XmlNode rootNode = doc.SelectSingleNode("configuration");

                    XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                    foreach(XmlNode node in firstLevelNodeList)
                    {
                        if(node.HasChildNodes)
                        {
                            XmlNode secondLevelNodeX = node.ChildNodes[0];
                            x = int.Parse(secondLevelNodeX.InnerText);

                            XmlNode secondLevelNodeY = node.ChildNodes[1];
                            y = int.Parse(secondLevelNodeY.InnerText);

                            XmlNode secondLevelNodeOpcity = node.ChildNodes[2];
                            opacity = int.Parse(secondLevelNodeOpcity.InnerText);

                            XmlNode secondLevelNodetopMost = node.ChildNodes[3];
                            topMost = bool.Parse(secondLevelNodetopMost.InnerText);
                        }
                    }
                }
            } catch(XmlException e) {}
        }

        /*从配置文件中获取logo的坐标
         *return 如果存在配置文件，即返回配置文件中的logo的x,y坐标，
         *否则创建配置文件，并返回logo的默认x,y坐标
         */
        public Point getMiniBallInitLocation() {
            return new Point(x, y);
        }

        public int getOpacity() {
            return opacity;
        }

        public bool getTopMost() {
            return topMost;
        }

        /*保存logo的位置信息*/
        public void saveInfos(int x, int y, int currentOpacity, bool isTopMost){
            try {
                FileInfo file = new FileInfo(configFilePath);
                if(!file.Exists) {
                    generateXMLFile(x, y, opacity, isTopMost); //创建配置文件，并保存信息
                    return;
                }
                else { //存在配置文件，更新配置信息
                    XmlDocument doc = new XmlDocument();
                    doc.Load(configFilePath);
                    XmlNode rootNode = doc.SelectSingleNode("configuration");

                    XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                    foreach(XmlNode node in firstLevelNodeList)
                    {
                        if(node.HasChildNodes)
                        {
                            XmlNode secondLevelNodeX = node.ChildNodes[0];
                            secondLevelNodeX.InnerText = x + "";

                            XmlNode secondLevelNodeY = node.ChildNodes[1];
                            secondLevelNodeY.InnerText = y + "";

                            XmlNode secondLevelNodeOpcity = node.ChildNodes[2];
                            secondLevelNodeOpcity.InnerText = currentOpacity + "";

                            XmlNode secondLevelNodeTopMost = node.ChildNodes[3];
                            secondLevelNodeTopMost.InnerText = isTopMost + "";
                        }
                    }
                    doc.Save(configFilePath);
                }
            }
            catch(XmlException e) {                  
            }
        }

        /*生成配置文件config.xml*/
        private void generateXMLFile(int defaultX, int defaultY, int opacity, bool topMost){
            try {
                //初始化一个xml实例
                XmlDocument xml = new XmlDocument();

                XmlElement rootElement = xml.CreateElement("configuration");
                xml.AppendChild(rootElement);
                    
                XmlElement firstElement = xml.CreateElement("appSettings");                
                rootElement.AppendChild(firstElement);
                   
                XmlElement xElement = xml.CreateElement("location.x");
                xElement.InnerText = defaultX + "";
                firstElement.AppendChild(xElement);

                XmlElement yElement = xml.CreateElement("location.y");
                yElement.InnerText = defaultY + "";
                firstElement.AppendChild(yElement);

                XmlElement oPacityElement = xml.CreateElement("opacity");
                oPacityElement.InnerText = opacity + "";
                firstElement.AppendChild(oPacityElement);

                XmlElement topMostElement = xml.CreateElement("topMost");
                topMostElement.InnerText = topMost + "";
                firstElement.AppendChild(topMostElement);

                xml.Save(configFilePath);
            } catch (Exception e) {
                
            }
        }
    }
}
