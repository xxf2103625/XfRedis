﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSRedis
{
    public interface ICSRedisClient:IDisposable
    {
        Dictionary<string, ConnectionPool> ClusterNodes { get; }

        T CacheShell<T>(string key, int timeoutSeconds, Func<T> getData, Func<T, string> serialize, Func<string, T> deserialize);
        T CacheShell<T>(string key, string field, int timeoutSeconds, Func<T> getData, Func<(T, long), string> serialize, Func<string, (T, long)> deserialize);
        T[] CacheShell<T>(string key, string[] fields, int timeoutSeconds, Func<string[], (string, T)[]> getData, Func<(T, long), string> serialize, Func<string, (T, long)> deserialize);
        Task<T> CacheShellAsync<T>(string key, int timeoutSeconds, Func<Task<T>> getDataAsync, Func<T, string> serialize, Func<string, T> deserialize);
        Task<T> CacheShellAsync<T>(string key, string field, int timeoutSeconds, Func<Task<T>> getDataAsync, Func<(T, long), string> serialize, Func<string, (T, long)> deserialize);
        Task<T[]> CacheShellAsync<T>(string key, string[] fields, int timeoutSeconds, Func<string[], Task<(string, T)[]>> getDataAsync, Func<(T, long), string> serialize, Func<string, (T, long)> deserialize);
        object Eval(string script, string key, params object[] args);
        Task<object> EvalAsync(string script, string key, params object[] args);
        bool Exists(string key);
        Task<bool> ExistsAsync(string key);
        bool Expire(string key, TimeSpan expire);
        Task<bool> ExpireAsync(string key, TimeSpan expire);
        string Get(string key);
        Task<string> GetAsync(string key);
        byte[] GetBytes(string key);
        Task<byte[]> GetBytesAsync(string key);
        long HashDelete(string key, params string[] fields);
        Task<long> HashDeleteAsync(string key, params string[] fields);
        bool HashExists(string key, string field);
        Task<bool> HashExistsAsync(string key, string field);
        string HashGet(string key, string field);
        Dictionary<string, string> HashGetAll(string key);
        Task<Dictionary<string, string>> HashGetAllAsync(string key);
        Task<string> HashGetAsync(string key, string field);
        long HashIncrement(string key, string field, long value = 1);
        Task<long> HashIncrementAsync(string key, string field, long value = 1);
        double HashIncrementFloat(string key, string field, double value = 1);
        Task<double> HashIncrementFloatAsync(string key, string field, double value = 1);
        string[] HashKeys(string key);
        Task<string[]> HashKeysAsync(string key);
        long HashLength(string key);
        Task<long> HashLengthAsync(string key);
        string[] HashMGet(string key, params string[] fields);
        Task<string[]> HashMGetAsync(string key, params string[] fields);
        string HashSet(string key, params object[] keyValues);
        Task<string> HashSetAsync(string key, params object[] keyValues);
        string HashSetExpire(string key, TimeSpan expire, params object[] keyValues);
        Task<string> HashSetExpireAsync(string key, TimeSpan expire, params object[] keyValues);
        string[] HashVals(string key);
        Task<string[]> HashValsAsync(string key);
        long Increment(string key, long value = 1);
        Task<long> IncrementAsync(string key, long value = 1);
        string[] Keys(string pattern);
        Task<string[]> KeysAsync(string pattern);
        string LIndex(string key, long index);
        Task<string> LIndexAsync(string key, long index);
        long LInsertAfter(string key, string pivot, string value);
        Task<long> LInsertAfterAsync(string key, string pivot, string value);
        long LInsertBefore(string key, string pivot, string value);
        Task<long> LInsertBeforeAsync(string key, string pivot, string value);
        long LLen(string key);
        Task<long> LLenAsync(string key);
        string LPop(string key);
        Task<string> LPopAsync(string key);
        long LPush(string key, params string[] value);
        Task<long> LPushAsync(string key, params string[] value);
        string[] LRang(string key, long start, long stop);
        Task<string[]> LRangAsync(string key, long start, long stop);
        long LRem(string key, long count, string value);
        Task<long> LRemAsync(string key, long count, string value);
        bool LSet(string key, long index, string value);
        Task<bool> LSetAsync(string key, long index, string value);
        bool LTrim(string key, long start, long stop);
        Task<bool> LTrimAsync(string key, long start, long stop);
        string[] MGet(params string[] keys);
        Task<string[]> MGetAsync(params string[] keys);
        IRedisClient[] PSubscribe(string[] channelPatterns, Action<CSRedisClient.PSubscribePMessageEventArgs> pmessage);
        long Publish(string channel, string data);
        Task<long> PublishAsync(string channel, string data);
        long Remove(params string[] key);
        Task<long> RemoveAsync(params string[] key);
        string RPop(string key);
        Task<string> RPopAsync(string key);
        long RPush(string key, params string[] value);
        Task<long> RPushAsync(string key, params string[] value);
        long SAdd(string key, params object[] memberScores);
        bool Set(string key, string value, int expireSeconds = -1);
        Task<bool> SetAsync(string key, string value, int expireSeconds = -1);
        bool SetBytes(string key, byte[] value, int expireSeconds = -1);
        Task<bool> SetBytesAsync(string key, byte[] value, int expireSeconds = -1);
        IRedisClient[] Subscribe(params (string, Action<CSRedisClient.SubscribeMessageEventArgs>)[] channels);
        long Ttl(string key);
        Task<long> TtlAsync(string key);
        long ZAdd(string key, params (double, string)[] memberScores);
        Task<long> ZAddAsync(string key, params (double, string)[] memberScores);
        long ZCard(string key);
        Task<long> ZCardAsync(string key);
        long ZCount(string key, double min, double max);
        Task<long> ZCountAsync(string key, double min, double max);
        double ZIncrBy(string key, string memeber, double increment = 1);
        Task<double> ZIncrByAsync(string key, string memeber, double increment = 1);
        long ZInterStoreMax(string destinationKey, params string[] keys);
        Task<long> ZInterStoreMaxAsync(string destinationKey, params string[] keys);
        long ZInterStoreMin(string destinationKey, params string[] keys);
        Task<long> ZInterStoreMinAsync(string destinationKey, params string[] keys);
        long ZInterStoreSum(string destinationKey, params string[] keys);
        Task<long> ZInterStoreSumAsync(string destinationKey, params string[] keys);
        string[] ZRange(string key, long start, long stop);
        Task<string[]> ZRangeAsync(string key, long start, long stop);
        string[] ZRangeByScore(string key, double minScore, double maxScore, long? limit = null, long offset = 0);
        Task<string[]> ZRangeByScoreAsync(string key, double minScore, double maxScore, long? limit = null, long offset = 0);
        long? ZRank(string key, string member);
        Task<long?> ZRankAsync(string key, string member);
        long ZRem(string key, params string[] member);
        Task<long> ZRemAsync(string key, params string[] member);
        long ZRemRangeByRank(string key, long start, long stop);
        Task<long> ZRemRangeByRankAsync(string key, long start, long stop);
        long ZRemRangeByScore(string key, double minScore, double maxScore);
        Task<long> ZRemRangeByScoreAsync(string key, double minScore, double maxScore);
        string[] ZRevRange(string key, long start, long stop);
        Task<string[]> ZRevRangeAsync(string key, long start, long stop);
        string[] ZRevRangeByScore(string key, double maxScore, double minScore, long? limit = null, long? offset = null);
        Task<string[]> ZRevRangeByScoreAsync(string key, double maxScore, double minScore, long? limit = null, long? offset = null);
        long? ZRevRank(string key, string member);
        Task<long?> ZRevRankAsync(string key, string member);
        double? ZScore(string key, string member);
        Task<double?> ZScoreAsync(string key, string member);
        long ZUnionStoreMax(string destinationKey, params string[] keys);
        Task<long> ZUnionStoreMaxAsync(string destinationKey, params string[] keys);
        long ZUnionStoreMin(string destinationKey, params string[] keys);
        Task<long> ZUnionStoreMinAsync(string destinationKey, params string[] keys);
        long ZUnionStoreSum(string destinationKey, params string[] keys);
        Task<long> ZUnionStoreSumAsync(string destinationKey, params string[] keys);
    }
}