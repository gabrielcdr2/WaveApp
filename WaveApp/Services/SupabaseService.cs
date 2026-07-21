using Supabase;

namespace WaveApp.Services;

public class SupabaseService
{
    private Client? _client;

    public async Task<Client> GetClient()
    {
        if (_client != null) return _client;

        const string url = "https://gdxdtqmsnicngcxijkgy.supabase.co";
        const string key = "sua_anon_key_aqui";

        _client = new Client(url, key, new SupabaseOptions
        {
            AutoConnectRealtime = false
        });

        await _client.InitializeAsync();
        return _client;
    }
}