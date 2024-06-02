# Project Name
404

## Overview
當前宿網處於斷線狀態，需要蒐集線索找到正確的IP，通過5層關卡，以重新連接宿網  
The current subnet is disconnected, and you need to gather clues to find the correct IP address. Pass through 5 levels to reconnect the subnet.

## Team Members
- 劉靖媛 412410003(@jyliew1912): 遊戲畫面顯示，額外道具，整合大師
- 陳湘昀 412410013(@sony0505): 地圖生成，部分道具，整合，debug大師
- 莊昀潔 412410020(@Jayechuang): terminal大師，主要道具
- 黃煜庭 412410051(@ccuhyt): monster，初始登入介面，部分地圖生成，部分繪圖
- 余沛穎 412410073(@YuPatty): player，分數，血量，BGM+音效，部分地圖生成，額外道具，繪圖大師，報告+README

## Project Description
玩家(小恐龍)一開始有7條命，碰到怪獸減1條命，遇到乖乖增1條命;可上下左右移動  

Character: Google Dinosaur  
Lives: Starts with 7 lives  
Monsters: Losing 1 life upon encounter  
"乖乖": Gaining 1 life upon encounter  
Movement: Can move up, down, left, and right  

#### 關卡詳細資訊:
第一關/第五層 (Application Layer):  
1.	躲避monster（熊）：在地圖上移動時，要躲避熊的DDOS攻擊，被碰到會扣一條生命值
2.	障礙物：在經過沼澤地區時，行動速度會減慢
3.	道具
    1.樹：遇到樹時，可以搖動它使其掉落蘋果。每顆蘋果會隨機包含不同的HTTP status code
  	2.乖乖：吃到乖乖道具可以增加一條生命值
4.  通關條件：當得到status code是200的蘋果時，可以前往這一關的終點並通關，如果拿的不是正確的蘋果則重回起點
第四層(Transport Layer):  
找到正確的人和玩家握手，找錯的話重新遊戲當前關卡;障礙物:珊瑚（行動減慢）  
第三層(Network Layer):  
找到正確學校IP通道，找錯減1條命;障礙物:仙人掌（減1命）  
第二層(Link Layer):  
找到正確的 MAC Address，有許多可能選項，需要找到提示解碼;障礙物:冰塊（暫停3秒）  
第一層(Physical Layer):  
時間限制內蒐集100個金幣交給宿管，遇到阿信壽司金幣增加10個，遇到離散時間增加5秒;障礙物:學分（行動減慢）    

#### Level Details:
第五層 (Application Layer):  
Objective: Avoid the bear's DDOS attacks and shake the trees to find the HTTP response status code 200.  
Obstacles: Swamps (slow down movement)  
第四層 (Transport Layer):  
Objective: Find the correct person to handshake with. Choosing the wrong person resets the current level.  
Obstacles: Coral (slow down movement)  
第三層 (Network Layer):  
Objective: Find the correct school IP tunnel. Choosing the wrong one reduces 1 life.  
Obstacles: Cacti (reduce 1 life)  
第二層 (Link Layer):  
Objective: Find the correct MAC Address among many options, using hints to decode the right one.  
Obstacles: Ice blocks (pause for 3 seconds)  
第一層 (Physical Layer):  
Objective: Collect 100 coins within the time limit and give them to the dorm supervisor. Encountering Ashin Sushi increases coins by 10, and encountering a discrete event increases the time by 5 seconds.  
Obstacles: Credits (slow down movement)  

#### 額外道具:
1.計時器
2.無敵狀態
3.磁鐵
4.天使
5.飛行器

#### Additional Items:  
1. **Timer**: Adds extra time to complete the current level.  
2. **Invincibility**: Grants temporary immunity to all obstacles and enemies.  
3. **Magnet**: Attracts nearby coins automatically for a limited time.  
4. **Angel**: Provides correct clues to help solve puzzles or find the right paths.  
5. **Flying Device**: Allows the player to fly over obstacles and enemies for a short duration.  

## Usage
操控上下左右按鍵移動小恐龍  
Control the Google Dinosaur using the arrow keys to move up, down, left, and right.  

## References
[無法穿透](https://blog.csdn.net/assassinsshadow/article/details/81301556)  
[Sprite Renderer](https://blog.csdn.net/BeUniqueToYou/article/details/74779608)  
[Unity - Keeping The Player Within Screen Boundaries](https://www.youtube.com/watch?v=ailbszpt_AI)  
[顯示/隱藏物件(SetActive)](https://ithelp.ithome.com.tw/articles/10266356?sc=rss.iron)  
[Unity 物件的啟用與停用](https://www.cg.com.tw/UnityCSharp/Content/SetActive.php)  
[Unity Script 常用語法教學](https://www.gameislearning.url.tw/article_content.php?getb=2&foog=9997#google_vignette)  
[Enemy](https://www.youtube.com/watch?v=jvtFUfJ6CP8)  
[Scene](https://www.youtube.com/watch?v=ge3koyyH3nc)  
[3小時製作一個遊戲 ｜ Unity 遊戲開發初學者教學](https://www.youtube.com/watch?v=nPW6tKeapsM)  
[Unity2018教程](https://www.youtube.com/watch?v=99FwnTyyDJg&list=PL_Pb2I110MfGAsoqtDs8-6kEU55wU8CnE)  
[Super Mario](https://www.youtube.com/playlist?list=PLqlFiJjSZ2x1mrMpSQgYdRm8PyWRTg6He)  
[Terminal](https://www.youtube.com/playlist?list=PLf9ofW-QospneJkI2HzX_OzTJavvZkItm)  
[How To Add An Existing Unity Project To Github](https://cadacreate.medium.com/how-to-add-existing-unity-project-to-github-916ad75160e7)  
[Dino](https://www.youtube.com/watch?v=UPvW8kYqxZk)  
[How to Transfer Data Between Scenes in Unity](https://www.youtube.com/watch?si=PHB6wadgr-KPYJZU&v=QG5i6DL7-to&feature=youtu.be)  




