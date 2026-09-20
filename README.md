# CompProg

競技プログラミング（AtCoder等）用の個人用テンプレート兼ライブラリです。

`Program.cs` 1ファイルで構成されており、ジャッジへの提出時はこのファイルの中身をそのままコピーするだけで使えるようになっています。

## 構成

- **Answer** — 解答コードを書く `Solve()` メソッド。
- **Library** — `Solve()` から利用する自作のアルゴリズム／データ構造ライブラリ（ModInt、UnionFind、SegmentTree、Graph、BinarySearch など）。

## 実行方法

```
dotnet build                          # デバッグビルド
dotnet build -c Release                # リリースビルド
dotnet run                             # 標準入出力でSolve()を実行
dotnet run -- input.txt output.txt     # 入出力をファイルにリダイレクト
```

- ターゲットフレームワーク: .NET 9
