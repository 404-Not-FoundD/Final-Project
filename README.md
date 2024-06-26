# Project Name
404

## Overview
當前宿網處於斷線狀態，需要蒐集線索找到正確的IP，通過5層關卡，以重新連接宿網  
Our game draws inspiration from "Mario" and "Google Dinosaur." Using Unity, we feature the Google Dinosaur as the main character.
The game begins with a Dormnet network disconnection. The player must collect clues to find the correct IP address and gather objects for each layer of the TCP/IP model, progressing through 5 levels to reconnect the network.  

[Overview Video](https://drive.google.com/file/d/1VS9lwYDGj4GksnwKxEKPgaC81aujIFuZ/view?usp=sharing)

## Team Members
- 劉靖媛 412410003(@jyliew1912): 遊戲畫面顯示(UI)、部分道具、場景控制、變數管理
- 陳湘昀 412410013(@sony0505): 檔案儲存、鏡頭控制、地圖優化、主要道具、程式整合、debug
- 莊昀潔 412410020(@Jayechuang): terminal、暫停MENU、部分繪圖、主要道具、地圖優化、debug
- 黃煜庭 412410051(@ccuhyt): 初始登入介面、地圖生成、部分繪圖、音效
- 余沛穎 412410073(@YuPatty): 角色移動、分數、血量、音效、部分道具、繪圖、報告+README

## Project Description
玩家(小恐龍)一開始有7條命，碰到怪獸減1條命，遇到乖乖增1條命;可上下左右移動  

Character: Google Dinosaur  
Lives: Starts with 7 lives  
Monsters: Losing 1 life upon encounter  
"乖乖": Gaining 1 life upon encounter  
Movement: Can move up, down, left, and right(controlled by the arrow keys)  

#### 關卡詳細資訊:
**第一關/第五層 (Application Layer)**  
1.	**躲避monster（蜜蜂）**：在地圖上移動時玩家要躲避蜜蜂的DDOS攻擊，被碰到會扣一條生命值  
3.	**障礙物**：經過沼澤地區玩家行動速度會減慢  
4.	**道具**  
    －**樹**：玩家搖動樹時會掉落蘋果，每顆蘋果隨機包含不同的HTTP status code  
  	－**乖乖**：吃到乖乖道具可以增加一條生命值  
5.  **通關條件**：當玩家取得status code為200的蘋果時，可以前往這一關的終點並通關，如果拿的不是正確的蘋果則重回起點  

**第二關/第四層 (Transport Layer)**  
1.	**躲避monster（鯊魚）**:在地圖上移動時玩家要躲避鯊魚的攻擊，被碰到會扣一條生命值  
2.	**障礙物**：碰到珊瑚會使玩家行動速度減慢  
3.	**道具**  
   －**貝殼**：玩家碰到貝殼時會掉落線索。每個貝殼掉落的線索隨機生成，線索都指向正確的乖乖人物的特徵  
   －**乖乖**：吃到乖乖道具可以增加一條生命值  
4.  **通關條件**：找到正確的乖乖人物和玩家握手，找錯的話重新開始當前關卡  

**第三關/第三層 (Network Layer)**  
1.	**躲避monster（蠍子）**：在地圖上移動時玩家要躲避蠍子，被碰到會扣一條生命值。  
2.	**障礙物**：碰到仙人掌扣除玩家一條生命值。  
3.	**道具**  
   －**椰子**：玩家碰到椰子樹時會掉落椰子，椰子包含隨機生成的線索，線索指引玩家找到正確的學校 IP 通道  
   －**乖乖**：吃到乖乖道具可以增加一條生命值  
4. **通關條件**：找到正確的學校 IP 通道，找錯扣除一條生命值  

**第四關/第二層 (Link Layer)**  
1.	**躲避monster（北極熊）**：在地圖上移動時玩家要躲避北極熊，被碰到則扣一條生命值。  
2.	**道具**  
   －**因紐特人**：提供玩家關於MAC地址的線索  
   －**乖乖**：吃到乖乖道具可以增加一條生命值  
3. **通關條件**：找到正確的 MAC 地址，有許多選項，需要找到提示解碼  

**第五關/第一層 (Physical Layer)**  
1.	**躲避monster（教授）**：在地圖上移動時玩家要躲避教授，被碰到會扣一條生命值。      
2.	**道具**  
   -**金幣** : 增加15個金幣  
   －**阿信壽司**：玩家遇到阿信壽司金幣增加 100 個  
   －**全家**：金幣減少 50 個，剩餘時間減少5秒  
   －**離散數學**：玩家遇到離散數學時間增加 10 秒    
   －**乖乖**：吃到乖乖道具可以增加一條生命值    
3. **通關條件**：在時間限制內蒐集 1000 個金幣交給宿管    
    

#### Level Details:  
**Level 1/第五層 (Application Layer):**  
1. **Avoid Monster (Bee):** Players must dodge bee DDOS attacks while moving around the map; touching a bear
costs one life.  
2. **Obstacles:** Moving through a swamp slows down the player.  
3. **Items:**  
  －**Tree:** Shaking a tree drops apples, each containing a random HTTP status code.  
  －**Guai Guai:** Consuming this item increases the player's life by one.  
4. **Goal:** Collect an apple with the status code 200 to proceed to the next level. If an
incorrect apple is picked, the player returns to the start.  
 
**Level 2/第四層 (Transport Layer):**  
1. **Avoid Monsters (Sharks):** Players must dodge sharks; touching one costs a life.  
2. **Obstacles:** Contact with coral slows the player down.  
3. **Items:**  
  －**Shells:** Picking up shells drops clues, each pointing to the characteristics of the
correct person.  
  －**Guai Guai:** Consuming this item increases the player's life by one.  
4. **Goal:**　Find and shake hands with the correct person. Incorrect choices restart the current level.  


**Level 3/第三層 (Network Layer):**    
1. **Avoid Monsters (Scorpions):**　Players must dodge scorpions; touching one costs a life.  
2. **Obstacles:**　Touching a cactus costs the player one life.  
3. **Items:**  
  －**Coconuts:** Shaking a coconut tree drops coconuts containing clues to the correct
school IP path.  
  －**Guai Guai:** Consuming this item increases the player's life by one.  
４. **Goal:** Find the correct school IP path. Incorrect choices cost one life.   

**Level 4/第二層 (Link Layer):**  
1. **Avoid Monsters (Polar Bears):** Players must dodge polar bears; touching one costs a life.  
2. **Items:**  
  －**Inuit:** Provides clues about MAC addresses.  
  －**Guai Guai:** Consuming this item increases the player's life by one.  
3. **Goal:**　Find the correct MAC address among many options using the provided clues

**Level 5/第一層 (Physical Layer):**    
1. **Avoid Monsters (Professors):**　Players must dodge professors; touching one costs a life.     
2. **Items:**  
  －**Sushi from Ah Xin:** Increases the player's coins by 100.  
  -**Family Mart:** Decreases the player's coins by 50 and minus 5 seconds to the timer.  
  -**Coin:** Increases the player's coins by 15.  
  －**Discrete Mathematics:** Adds 10 seconds to the timer.    
  －**Guai Guai:** Consuming this item increases the player's life by one.    
3. **Goal:**　Collect 1000 coins within the time limit and hand them to the dorm manager.    


#### 額外道具:
1.計時器
2.無敵狀態
3.磁鐵
4.暫停MENU
5.記憶存儲玩家資訊

#### Additional Items:  
1. **Timer**: Adds extra time to complete the current level.  
2. **Invincibility**: Grants temporary immunity to all obstacles and enemies when eating more than 3 乖乖.  
3. **Magnet**: Attracts nearby coins automatically for a limited time.  
4. **Pasuing menu**: When the pause button is pressed, this system can pause and display five items:  
(1)Continue Game  (2)Restart Game  (3)Team Introduction  (4)How to Play  (5)Exit Game
5. **Store player information in memory**: When entering the login screen, the player inputs their information, and the computer simultaneously saves the information.  

https://github.com/404-Not-FoundD/Final-Project/assets/158292801/05343da7-5fbb-46f4-9767-6411b5a7e2e5  

## Usage
按下空白建開始。之後操控上下左右，空白建(可以連跳)或WASD按鍵移動小恐龍    
Press the spacebar to start. Then control the small dinosaur using the arrow keys (up, down, left, right), the spacebar (which allows multiple jumps), or the WASD keys to move.  

## Executable File
[Download and execute this zip folder](https://drive.google.com/file/d/1H9Lfk4mBOspz4fu91dX5UDaTZt2enfva/view?usp=sharing)

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




