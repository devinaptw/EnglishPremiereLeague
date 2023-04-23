-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 23, 2023 at 05:45 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `premierleaguedata`
--

-- --------------------------------------------------------

--
-- Table structure for table `match_data`
--

CREATE TABLE `match_data` (
  `id` int(11) NOT NULL,
  `home_team` varchar(200) NOT NULL,
  `away_team` varchar(200) NOT NULL,
  `minute` int(11) NOT NULL,
  `team_name` varchar(200) NOT NULL,
  `player_name` varchar(200) NOT NULL,
  `type` enum('Yellow Card','Red Card','Goal') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `match_data`
--

INSERT INTO `match_data` (`id`, `home_team`, `away_team`, `minute`, `team_name`, `player_name`, `type`) VALUES
(1, 'Liverpool', 'Manchester United', 41, 'Liverpool', 'Fabinho', 'Yellow Card'),
(2, 'Liverpool', 'Manchester United', 43, 'Liverpool', 'Cody Gakpo', 'Goal'),
(3, 'Liverpool', 'Manchester United', 47, 'Liverpool', 'Darwin Nunez', 'Goal'),
(4, 'Liverpool', 'Manchester United', 50, 'Liverpool', 'Cody Gakpo', 'Goal'),
(5, 'Liverpool', 'Manchester United', 53, 'Manchester United', 'Antony', 'Yellow Card'),
(6, 'Liverpool', 'Manchester United', 61, 'Manchester United', 'Lisandro Martinez', 'Yellow Card'),
(7, 'Liverpool', 'Manchester United', 64, 'Manchester United', 'Scott McTominac', 'Yellow Card'),
(8, 'Liverpool', 'Manchester United', 75, 'Liverpool', 'Darwin Nunez', 'Goal'),
(9, 'Liverpool', 'Manchester United', 88, 'Liverpool', 'Roberto Firmino', 'Goal'),
(10, 'Liverpool', 'Manchester United', 66, 'Liverpool', 'Mohamed Salah', 'Goal'),
(11, 'Liverpool', 'Manchester United', 83, 'Liverpool', 'Mohamed Salah', 'Goal');

-- --------------------------------------------------------

--
-- Table structure for table `player_data`
--

CREATE TABLE `player_data` (
  `id` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `position` varchar(200) NOT NULL,
  `playing_position` varchar(200) NOT NULL,
  `team_name` varchar(200) NOT NULL,
  `nationality` varchar(200) NOT NULL,
  `yellow_card` int(11) NOT NULL,
  `red_card` int(11) NOT NULL,
  `goal_score` int(11) NOT NULL,
  `penalty_missed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `player_data`
--

INSERT INTO `player_data` (`id`, `name`, `position`, `playing_position`, `team_name`, `nationality`, `yellow_card`, `red_card`, `goal_score`, `penalty_missed`) VALUES
(1, 'David de Gea', 'GK', 'Goalkeeper', 'Manchester United', 'Spain', 0, 0, 0, 0),
(2, 'Tom Heaton', 'GK', 'Goalkeeper', 'Manchester United', 'England', 0, 0, 0, 0),
(3, 'Nathan Bishop', 'GK', 'Goalkeeper', 'Manchester United', 'England', 0, 0, 0, 0),
(4, 'Phil Jones', 'CB', 'Defender', 'Manchester United', 'England', 0, 0, 0, 0),
(5, 'Harry Maguire', 'CB', 'Defender', 'Manchester United', 'England', 0, 0, 0, 0),
(6, 'Raphael Varane', 'CB', 'Defender', 'Manchester United', 'France', 0, 0, 0, 0),
(7, 'Diogo Dalot', 'CB', 'Defender', 'Manchester United', 'Portugal', 0, 0, 0, 0),
(8, 'Tyrell Malacia', 'CB', 'Defender', 'Manchester United', 'Netherlands', 0, 0, 0, 0),
(9, 'Bruno Frenandes', 'DM', 'Midfelder', 'Manchester United', 'Portugal', 0, 0, 0, 0),
(10, 'Scott McTominay', 'DM', 'Midfelder', 'Manchester United', 'Scotland', 0, 0, 0, 0),
(11, 'Alejandro Garnacho', 'AM', 'Forward', 'Manchester United', 'Argentina', 0, 0, 2, 0),
(12, 'Marcus Rashford', 'AM', 'Forward', 'Manchester United', 'England', 0, 0, 15, 0),
(13, 'Jadon Sancho', 'AM', 'Forward', 'Manchester United', 'England', 0, 0, 4, 0),
(14, 'Anthony Elanga', 'AM', 'Forward', 'Manchester United', 'Sweden', 0, 0, 0, 0),
(15, 'Wout Weghorst', 'AM', 'Forward', 'Manchester United', 'Netherlands', 0, 0, 0, 0),
(16, 'Alisson', 'GK', 'Goalkeeper', 'Liverpool', 'Brazil', 0, 0, 0, 0),
(17, 'Adrian', 'GK', 'Goalkeeper', 'Liverpool', 'Spain', 0, 0, 0, 0),
(18, 'Harvey Davies', 'GK', 'Goalkeeper', 'Liverpool', 'England', 0, 0, 0, 0),
(19, 'Joe Gomez', 'CB', 'Defender', 'Liverpool', 'England', 0, 0, 0, 0),
(20, 'Andrew Robertson', 'CB', 'Defender', 'Liverpool', 'Scotland', 0, 0, 0, 0),
(21, 'Joel Maatip', 'CB', 'Defender', 'Liverpool', 'Cameroon', 0, 0, 0, 0),
(22, 'Nathaniel Phillips', 'CB', 'Defender', 'Liverpool', 'England', 0, 0, 0, 0),
(23, 'Stefan Bajcetic', 'CB', 'Defender', 'Liverpool', 'Spain', 0, 0, 1, 0),
(24, 'Fabinho', 'DM', 'Midfielder', 'Liverpool', 'Brazil', 0, 0, 0, 0),
(25, 'Thiago', 'DM', 'Midfielder', 'Liverpool', 'Spain', 0, 0, 0, 0),
(26, 'James Milner', 'DM', 'Midfielder', 'Liverpool', 'England', 0, 0, 0, 0),
(27, 'Roberto Firmino', 'AM', 'Forward', 'Liverpool', 'Brazil', 0, 0, 9, 0),
(28, 'Mohamed Salah', 'AM', 'Forward', 'Liverpool', 'Egypt', 0, 0, 16, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `match_data`
--
ALTER TABLE `match_data`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `player_data`
--
ALTER TABLE `player_data`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `match_data`
--
ALTER TABLE `match_data`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `player_data`
--
ALTER TABLE `player_data`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
