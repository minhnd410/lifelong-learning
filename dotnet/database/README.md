1. **ACID**

![image](https://github.com/minhnd410/lifelong-learning/assets/91967823/70a8148d-15e2-441b-9e69-7bc4041a8a55)

2. **Scalable**
3. **Full-text search:** [Viblo](https://viblo.asia/p/fulltext-search-don-gian-ma-huu-ich-DXOGRjbPGdZ)
    1. Inverted Index là kĩ thuật thay vì index theo đơn vị row(document) giống như mysql thì chúng ta sẽ tiến hành index theo đơn vị term, các kỹ thuật
        1. Tokenization technique (thông qua N-Gram hoặc Morphological Analysis)
        2. Query technique
        3. Scoring technique.
4. **Real-time**
5. **Graph**
6. **Relational**
7. **Multi-tenant:** Ứng dụng trong SaaS, cần quan tâm khi thiết kế DB:
    - Mức độ cô lập dữ liệu (tenant data isolation)
    - Khả năng sao lưu và phục hồi từng tenant
    - Khả năng mã hóa dữ liệu tenant
    
    Chọn 1 trong 3 cách sau để xây dựng DB cho ứng dụng của mình.
    
    - Mỗi tenant dùng một database riêng biệt.
    - Dùng chung database nhưng chia cho mỗi tenant một schema riêng hoặc table riêng (nếu DB bạn chọn không có schema).
    - Dùng chung tất, cả database lẫn schema hay table
8. **Temporal** **data**: dữ liệu hướng thời gian
9. **Schemaless/ Schemafull**
10. **Serverless/ Embebbed**
