CREATE TABLE `cuisines` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `cuisines` (`id`, `name`) VALUES
(1, 'Thai'),
(2, 'Pizza'),
(3, 'Dessert'),
(4, 'Burgers'),
(5, 'Ribs'),
(33, 'Dessert');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cuisines`
--
ALTER TABLE `cuisines`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cuisines`
--
ALTER TABLE `cuisines`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;



  CREATE TABLE `restuarants` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `cuisine_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `restuarants`
INSERT INTO `restuarants` (`id`, `name`, `cuisine_id`) VALUES
(4, 'Burgerville', 0),
(5, 'SIzzle PIe', 2),
(6, 'Pizza Hut', 2),
(7, 'pizza place', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `restuarants`
--
ALTER TABLE `restuarants`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `restuarants`
--
ALTER TABLE `restuarants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;