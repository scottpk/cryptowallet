using QRCoder;
using NBitcoin;
using NBitcoin.Tests;
using NBitcoin.RPC;

namespace cryptowallet
{
    public class BitcoinWallet : BaseWallet
    {
        NodeBuilder env;
        CoreNode me;
        RPCClient rpc;
        MoneyUnit displayUnit = MoneyUnit.BTC;
        Network net = Network.TestNet;
        public BitcoinWallet(){
            env = NodeBuilder.Create(NodeDownloadData.Bitcoin.v0_21_1, net);
            me =  env.CreateNode();
            rpc = me.CreateRPCClient();
            env.StartAll();
        }
        public override string Icon {
            get {
                return "data:image/svg+xml;base64,PCEtLSBDcmVhdGVkIHdpdGggSW5rc2NhcGUgKGh0dHA6Ly93d3cuaW5rc2NhcGUub3JnLykgLS0+DQo8c3ZnIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiBoZWlnaHQ9IjY0IiB3aWR0aD0iNjQiIHZlcnNpb249IjEuMSIgeG1sbnM6Y2M9Imh0dHA6Ly9jcmVhdGl2ZWNvbW1vbnMub3JnL25zIyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIj4NCjxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKDAuMDA2MzA4NzYsLTAuMDAzMDE5ODQpIj4NCjxwYXRoIGZpbGw9IiNmNzkzMWEiIGQ9Im02My4wMzMsMzkuNzQ0Yy00LjI3NCwxNy4xNDMtMjEuNjM3LDI3LjU3Ni0zOC43ODIsMjMuMzAxLTE3LjEzOC00LjI3NC0yNy41NzEtMjEuNjM4LTIzLjI5NS0zOC43OCw0LjI3Mi0xNy4xNDUsMjEuNjM1LTI3LjU3OSwzOC43NzUtMjMuMzA1LDE3LjE0NCw0LjI3NCwyNy41NzYsMjEuNjQsMjMuMzAyLDM4Ljc4NHoiLz4NCjxwYXRoIGZpbGw9IiNGRkYiIGQ9Im00Ni4xMDMsMjcuNDQ0YzAuNjM3LTQuMjU4LTIuNjA1LTYuNTQ3LTcuMDM4LTguMDc0bDEuNDM4LTUuNzY4LTMuNTExLTAuODc1LTEuNCw1LjYxNmMtMC45MjMtMC4yMy0xLjg3MS0wLjQ0Ny0yLjgxMy0wLjY2MmwxLjQxLTUuNjUzLTMuNTA5LTAuODc1LTEuNDM5LDUuNzY2Yy0wLjc2NC0wLjE3NC0xLjUxNC0wLjM0Ni0yLjI0Mi0wLjUyN2wwLjAwNC0wLjAxOC00Ljg0Mi0xLjIwOS0wLjkzNCwzLjc1czIuNjA1LDAuNTk3LDIuNTUsMC42MzRjMS40MjIsMC4zNTUsMS42NzksMS4yOTYsMS42MzYsMi4wNDJsLTEuNjM4LDYuNTcxYzAuMDk4LDAuMDI1LDAuMjI1LDAuMDYxLDAuMzY1LDAuMTE3LTAuMTE3LTAuMDI5LTAuMjQyLTAuMDYxLTAuMzcxLTAuMDkybC0yLjI5Niw5LjIwNWMtMC4xNzQsMC40MzItMC42MTUsMS4wOC0xLjYwOSwwLjgzNCwwLjAzNSwwLjA1MS0yLjU1Mi0wLjYzNy0yLjU1Mi0wLjYzN2wtMS43NDMsNC4wMTksNC41NjksMS4xMzljMC44NSwwLjIxMywxLjY4MywwLjQzNiwyLjUwMywwLjY0NmwtMS40NTMsNS44MzQsMy41MDcsMC44NzUsMS40MzktNS43NzJjMC45NTgsMC4yNiwxLjg4OCwwLjUsMi43OTgsMC43MjZsLTEuNDM0LDUuNzQ1LDMuNTExLDAuODc1LDEuNDUzLTUuODIzYzUuOTg3LDEuMTMzLDEwLjQ4OSwwLjY3NiwxMi4zODQtNC43MzksMS41MjctNC4zNi0wLjA3Ni02Ljg3NS0zLjIyNi04LjUxNSwyLjI5NC0wLjUyOSw0LjAyMi0yLjAzOCw0LjQ4My01LjE1NXptLTguMDIyLDExLjI0OWMtMS4wODUsNC4zNi04LjQyNiwyLjAwMy0xMC44MDYsMS40MTJsMS45MjgtNy43MjljMi4zOCwwLjU5NCwxMC4wMTIsMS43Nyw4Ljg3OCw2LjMxN3ptMS4wODYtMTEuMzEyYy0wLjk5LDMuOTY2LTcuMSwxLjk1MS05LjA4MiwxLjQ1N2wxLjc0OC03LjAxYzEuOTgyLDAuNDk0LDguMzY1LDEuNDE2LDcuMzM0LDUuNTUzeiIvPg0KPC9nPg0KPC9zdmc+";
            }
        }
        public override decimal Balance{
            get {
                return rpc.GetBalance().ToDecimal(displayUnit);
            }
        }
        public override string Send(string address, decimal amount, System.Threading.CancellationToken token){
            //throw new System.NotImplementedException();
            var txid = rpc.SendToAddress(BitcoinAddress.Create(address, net), Money.Coins(amount), cancellationToken: token);
            return txid.ToString();
        }
        ~BitcoinWallet(){
            env.Dispose();
        }
    }
}