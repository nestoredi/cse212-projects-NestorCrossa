using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// Problem 2 - Test cases implemented and documented to find defects in PriorityQueue.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and Dequeue them.
    // Expected Result: The item with the highest priority (Item C - Priority 5) is removed first.
    // Defect(s) Found: The original implementation loop often skips the last item in the queue (index < Count - 1 instead of index < Count).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 2);
        priorityQueue.Enqueue("Item B", 1);
        priorityQueue.Enqueue("Item C", 5);
        priorityQueue.Enqueue("Item D", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item C", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items where more than one item has the same highest priority.
    // Expected Result: The item closest to the front of the queue (FIFO) should be removed first (Item B).
    // Defect(s) Found: The loop condition uses `>=` instead of `>`, causing it to pick the last item with that priority instead of the first one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 2);
        priorityQueue.Enqueue("Item B", 5); // First with high priority
        priorityQueue.Enqueue("Item C", 3);
        priorityQueue.Enqueue("Item D", 5); // Second with high priority

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item B", result);
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the exact message "The queue is empty."
    // Defect(s) Found: The original code may return null or throw a different exception type (like ArgumentOutOfRangeException) instead of validating if it's empty.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An InvalidOperationException should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}