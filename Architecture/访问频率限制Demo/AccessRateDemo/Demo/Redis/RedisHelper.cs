/*  QQ群：166843154  http://www.cnblogs.com/1996V/p/8127576.html */
using StackExchange.Redis;
using System.Text;

namespace Redis
{
    public class RedisHelper
    {
        private static ConnectionMultiplexer _instance;
        private int _num;
        static RedisHelper()
        {
            _instance = GetManager();
        }
        public RedisHelper(int Num)
        {
            _num = Num;
        }
        public static ConnectionMultiplexer GetManager()
        {
            var connect = ConnectionMultiplexer.Connect("127.0.0.1:6379,password=123");
            return connect;
        }


        /// <summary>
        /// 如果 大于10(AccountNum) 就返回1   否则就增加一条集合中的元素 并返回 空
        /// </summary>
        /// <param name="zcardKey"></param>
        /// <param name="score"></param>
        /// <param name="zcardValue"></param>
        /// <param name="AccountNum"></param>
        /// <returns></returns>
        public string LuaAddAccoundSorted(string zcardKey, double score, string zcardValue, int AccountNum)
        {
            string str = "local uu = redis.call('zcard',@zcardKey) if (uu >=tonumber(@AccountNum)) then return 1 else redis.call('zadd',@zcardKey,@score,@zcardValue)  end";
            var re = _instance.GetDatabase(_num).ScriptEvaluate(LuaScript.Prepare(str), new { zcardKey = zcardKey, score = score, zcardValue = zcardValue, AccountNum=AccountNum });
            return re.ToString();
        }

        /// <summary>
        /// 遍历当前所有前缀的有序集合，如果数量为0，那么就返回1 否则 就删除 满足最大分值条件区间的元素，如果该集合个数为0则消失
        /// </summary>
        /// <param name="zcardPrefix"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public string LuaForeachRemove(string zcardPrefix, double score)
        {
            StringBuilder str = new StringBuilder();
            str.Append("local uu = redis.call('keys',@zcardPrefix) ");
            str.Append("if(#uu==0) then");
            str.Append("   return 1 ");
            str.Append("else ");
            str.Append("   for i=1,#uu do ");
            str.Append("       redis.call('ZREMRANGEBYSCORE',uu[i],0,@score) ");
            str.Append("       if(redis.call('zcard',uu[i])==0) then ");
            str.Append("           redis.call('del',uu[i]) ");
            str.Append("       end ");
            str.Append("   end ");
            str.Append("end ");
            var re = _instance.GetDatabase(_num).ScriptEvaluate(LuaScript.Prepare(str.ToString()), new { zcardPrefix = zcardPrefix + "*", score = score });
            return re.ToString();
        }
    }
}
