import os
import sys
import time


def outTXT(PATH, strOUT):  # 產TXT函數
    f = open(PATH, 'a', encoding="UTF-8")
    f.write(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()) + " " + strOUT)
    f.close()


def main():
    ip = 'www.google.com'
    # 實現pingIP地址的功能，-c1指傳送報文一次，-w1指等待1秒
    backinfo = os.system('ping -c 1 -w 1 %s' % ip)

    if backinfo == 0:
        print(time.strftime("%Y/%m/%d %H:%M:%S", time.localtime()) + " 網路連接正常\n")
        outTXT("WIFI_log.txt", " 網路連接正常\n")

    else:
        print(time.strftime("%Y/%m/%d %H:%M:%S", time.localtime()) + " 網路連接異常\n")
        outTXT("WIFI_log.txt", " 網路連接異常，呼叫bat重新連接WIFI\n")
        os.system("WIFI.bat")

    time.sleep(300)
    main()


main()
