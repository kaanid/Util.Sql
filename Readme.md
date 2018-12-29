## 生成sql

```

var builder = new SqlServerBuilder();
builder.Select<Sample>(t => new object[] { t.Email, t.BoolValue })
    .Select<Sample2>(t => new object[] { t.Description, t.IntValue })
    .From<Sample>("a")
    .LeftJoin<Sample2>("b").On<Sample, Sample2>((l, r) => l.Email == r.StringValue && l.IntValue != r.IntValue);

string sqlStr=_builder.ToSql();

```