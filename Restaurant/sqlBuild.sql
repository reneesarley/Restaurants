CREATE DATABASE diningTracker;

USE diningTracker;

CREATE TABLE `cuisines` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cuisines`
--

INSERT INTO `cuisines` (`id`, `name`) VALUES
(1, 'Thai'),
(2, 'Pizza'),
(3, 'Dessert'),
(4, 'Burgers'),
(5, 'Ribs'),
(33, 'Dessert'),
(42, 'new cuisine test'),
(43, 'testName');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

  CREATE TABLE `restuarants` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `cuisine_id` int(11) NOT NULL,
  `allows_dogs` tinyint(1) NOT NULL DEFAULT '0',
  `serves_alcohol` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `restuarants`
--

INSERT INTO `restuarants` (`id`, `name`, `cuisine_id`, `allows_dogs`, `serves_alcohol`) VALUES
(5, 'Sizzle PIe', 2, 0, 1),
(6, 'Pizza Hut', 2, 0, 0),
(7, 'pizza place', 2, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `restuarants`
--
ALTER TABLE `restuarants`
  ADD PRIMARY KEY (`id`);


INSERT INTO `restuarants` ( `name`, `cuisine_id`, `allows_dogs`, `serves_alcohol`) VALUES
( 'White Owl', 2, 1, 1);

