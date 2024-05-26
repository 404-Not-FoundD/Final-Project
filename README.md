# Project Name
404
## Overview
Brief description of the project and its purpose.
當前宿網處於斷線狀態，需要蒐集線索找到正確的IP，通過5層關卡，以重新連接宿網。

## Team Members
- 劉靖媛 412410003(@jyliew1912):遊戲畫面顯示，額外道具，整合大師
- 陳湘昀 412410013(@sony0505):地圖生成，部分道具，debug大師
- 莊昀潔 412410020(@Jayechuang): terminal大師，主要道具
- 黃煜庭 412410051(@ccuhyt):monster，部分地圖生成，部分繪圖
- 余沛穎 412410073(@YuPatty): player，分數，血量，部分地圖生成，額外道具，繪圖大師，報告+README

## Project Description
Provide a more detailed description of the project, its goals, and any relevant information.
玩家(小恐龍)一開始有7條命，碰到怪獸減1條命，遇到乖乖增1條命;可上下左右

第一層(Application Layer):躲避熊的DDOS攻擊並搖樹找到HTTP reponse status code 200;障礙物:沼澤（行動減慢）
第二層(Transport Layer):找到正確的人和玩家握手，找錯的話重新遊戲當前關卡;障礙物:珊瑚（行動減慢）
第三層(Network Layer):找到正確學校IP通道，找錯減1條命;障礙物:仙人掌（減1命）
第四層(Link Layer):找到正確的 MAC Address，有許多可能選項，需要找到提示解碼;障礙物:冰塊（暫停3秒）
第五層(Physical Layer):時間限制內蒐集100個金幣交給宿管，遇到阿信壽司金幣增加10個，遇到離散時間增加5秒;障礙物:學分（行動減慢）

額外道具:
1.計時器
2.無敵狀態
3.磁鐵
4.天使
5.飛行器

## Usage
Explain how to use the project, including any command-line options, configuration settings, or usage examples. Provide code snippets if necessary.
操控上下左右按鍵移動小恐龍

## References
[無法穿透](https://blog.csdn.net/assassinsshadow/article/details/81301556)




