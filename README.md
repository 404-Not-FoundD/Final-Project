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
1.	躲避monster（熊）：在地圖上移動時玩家要躲避熊的DDOS攻擊，被碰到會扣一條生命值
2.	障礙物：經過沼澤地區玩家行動速度會減慢
3.	道具
    1.樹：玩家搖動樹時會掉落蘋果，每顆蘋果隨機包含不同的HTTP status code
  	2.乖乖：吃到乖乖道具可以增加一條生命值
4.  通關條件：當玩家取得status code為200的蘋果時，可以前往這一關的終點並通關，如果拿的不是正確的蘋果則     重回起點
第二關/第四層 (Transport Layer):  
1.	躲避monster（鯊魚）：在地圖上移動時玩家要躲避鯊魚的攻擊，被碰到會扣一條生命值
2.	障礙物：碰到珊瑚會使玩家行動速度減慢
3.	道具
   1.貝殼：玩家碰到貝殼時會掉落線索。每個貝殼掉落的線索隨機生成，線索都指向正確的乖乖人物的特徵
   2.乖乖：吃到乖乖道具可以增加一條生命值
4.  通關條件：找到正確的乖乖人物和玩家握手，找錯的話重新開始當前關卡
第三關/第三層 (Network Layer):  
1.	躲避monster（蠍子）：在地圖上移動時玩家要躲避蠍子，被碰到會扣一條生命值。
2.	障礙物：碰到仙人掌扣除玩家一條生命值。
3.	道具
   1.椰子：玩家碰到椰子樹時會掉落椰子，椰子包含隨機生成的線索，線索指引玩家找到正確的學校 IP 通道
   2.乖乖：吃到乖乖道具可以增加一條生命值
4. 通關條件：找到正確的學校 IP 通道，找錯扣除一條生命值
第四關/第二層 (Link Layer):  
1.	躲避monster（北極熊）：在地圖上移動時玩家要躲避北極熊，被碰到則扣一條生命值。
2.	障礙物：碰到冰塊玩家暫停移動3秒
3.	道具
   1.因紐特人：提供玩家關於MAC地址的線索
   2.乖乖：吃到乖乖道具可以增加一條生命值
4. 通關條件：找到正確的 MAC 地址，有許多選項，需要找到提示解碼
第五關/第一層 (Physical Layer):  
1.	躲避monster（教授）：在地圖上移動時玩家要躲避教授，被碰到會扣一條生命值。
2.	障礙物：碰到學分玩家行動速度減慢
3.	道具
   1.阿信壽司：玩家遇到阿信壽司金幣增加 10 個
   2.離散數學：玩家遇到離散數學時間增加 5 秒
   3.乖乖：吃到乖乖道具可以增加一條生命值
4. 通關條件：在時間限制內蒐集 100 個金幣交給宿管
    

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




