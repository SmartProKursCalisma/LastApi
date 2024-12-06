namespace LasApi
{
    public class MockDataManager
    {
        private IList<MockData> datas;
        public MockDataManager()
        {
            datas = new List<MockData>();
            datas.Add(new MockData() { Id = 1, Fullname = "Melih Ömer KAMAR", Job = "Software Develeoper" });
            datas.Add(new MockData() { Id = 2, Fullname = "Eylem BAKCA", Job = "Software Develeoper" });
            datas.Add(new MockData() { Id = 3, Fullname = "Selim TOPAL", Job = "Software Develeoper" });
        }
        public IEnumerable<MockData> GetAll()
        {
            return datas;
        }
        public void AddData(MockData data)
        {
            datas.Add(data);
        }
        public void RemoveData(MockData data)
        {
            datas.Remove(data);
        }
        public MockData GetData(int id)
        {
            return datas.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateData(MockData data)
        {
            var current = datas.FirstOrDefault(x => x.Id == data.Id);
            current.Job = data.Job;
            current.Fullname = data.Fullname;
        }

    }
}
