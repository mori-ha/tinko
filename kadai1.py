import numpy as np
import matplotlib.pyplot as plt

# 部品の信頼度のリスト
R_values = [0.9, 0.99, 0.999, 0.9999, 0.99999]
# 部品数の範囲（1から100万）
n = np.logspace(0, 6, 1000)  # 常用対数スケールでの部品数

plt.figure(figsize=(10, 6))

for R in R_values:
    R_item = R**n  # アイテム全体の信頼度の計算
    plt.plot(np.log10(n), R_item, label=f'R = {R}')

plt.title('アイテムの信頼度 vs 部品数')
plt.xlabel('部品数 (常用対数スケール)')
plt.ylabel('アイテムの信頼度')
plt.grid(which='both', linestyle='--', linewidth=0.5)
plt.legend()
plt.ylim(0, 1)
plt.yticks(np.arange(0, 1.1, 0.1))
plt.show()